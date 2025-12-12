using API_Vadras.DTO.Porudzbina;
using API_Vadras.DTO.Proizvod;
using API_Vadras.DTO.StavkaPorudzbine;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace API_Vadras.Repository.PorudzbinaRepo
{
    public class PorudzbinaEF : IPorudzbina
    {
        private readonly VadrasDbContext dbContext;

        public PorudzbinaEF(VadrasDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<UcitajSvePorudzbineDTO>> VratiSvePorudzbine()
        {
            var porudzbine = await dbContext.Porudzbine
        .Include(p => p.Radnik)
        .Include(p => p.Stavke)
            .ThenInclude(s => s.Proizvod)
        .OrderByDescending(p => p.Id)
        .ToListAsync();

            var rezultat = porudzbine.Select(p => new UcitajSvePorudzbineDTO
            {
                Id = p.Id,
                BrRacuna = p.BrRacuna,
                ImePrezime = p.ImePrezime,
                Adresa = p.Adresa,
                BrojTelefona = p.BrojTelefona,
                DatumPorudzbine = p.DatumPorudzbine,
                DatumIsporuke = p.DatumIsporuke,
                Status = p.Status
            }).ToList();

            return rezultat;
        }

        public async Task<string> KreirajPorudzbinu(KreirajPorudzbinuDTO dto)
        {
            // 1. osnovne validacije
            if (dto == null || dto.Stavke == null || !dto.Stavke.Any())
                return null;

            // 2. da li radnik postoji
            var radnikPostoji = await dbContext.Radnici
                .AnyAsync(r => r.Id == dto.RadnikId);

            if (!radnikPostoji)
                return null;

            // 3. provera dupliranog Rb unutar iste porudžbine
            var rbs = dto.Stavke.Select(s => s.Rb).ToList();
            if (rbs.Count != rbs.Distinct().Count())
                return null;

            // 4. učitaj sve proizvode koji se koriste u stavkama
            var proizvodIds = dto.Stavke
                .Select(s => s.ProizvodId)
                .Distinct()
                .ToList();

            var proizvodi = await dbContext.Proizvodi
                .Where(p => proizvodIds.Contains(p.Id))
                .ToListAsync();

            // ako neki ProizvodId ne postoji u bazi → prekid
            if (proizvodi.Count != proizvodIds.Count)
                return null;

            // 5. kreiraj porudžbinu
            var porudzbina = new Porudzbina
            {
                BrRacuna = dto.BrRacuna,
                ImePrezime = dto.ImePrezime,
                Adresa = dto.Adresa,
                BrojTelefona = dto.BrojTelefona,
                DatumPorudzbine = dto.DatumPorudzbine,
                DatumIsporuke = dto.DatumIsporuke,
                AparatZaKartice = dto.AparatZaKartice,
                Lift = dto.Lift,
                Stan = dto.Stan,
                Napomena = dto.Napomena,
                Status = Status.Zakazano,
                RadnikId = dto.RadnikId,
                Stavke = new List<StavkaPorudzbine>()
            };

            // 6. kreiraj stavke i veži proizvode
            foreach (var s in dto.Stavke)
            {
                var proizvod = proizvodi.First(p => p.Id == s.ProizvodId);

                var stavka = new StavkaPorudzbine
                {
                    Rb = s.Rb,
                    Kolicina = s.Kolicina,
                    Boja = s.Boja,
                    Dimenzija = s.Dimenzija,
                    ProizvodId = proizvod.Id,
                    Proizvod = proizvod,
                    Porudzbina = porudzbina,
                    FinalnaCena = s.FinalnaCena
                };

                porudzbina.Stavke.Add(stavka);
            }

            dbContext.Porudzbine.Add(porudzbina);
            await dbContext.SaveChangesAsync();

            return porudzbina.BrRacuna;
        }

        public async Task<bool> ObrisiPorudzbinu(int id)
        {
            var porudzbina = await dbContext.Porudzbine.FirstOrDefaultAsync(p => p.Id == id);
            if (porudzbina != null)
            {
                dbContext.Porudzbine.Remove(porudzbina);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<VratiPorudzbinuDTO> VratiPorudzbinu(int id)
        {
            var r = await dbContext.Porudzbine
        .Include(p => p.Radnik)
        .Include(p => p.Stavke)
            .ThenInclude(s => s.Proizvod)
        .OrderByDescending(p => p.Id)
        .FirstOrDefaultAsync(p => p.Id == id);
            if (r == null) return null;

            var porudzbina = new VratiPorudzbinuDTO
            {
                Id = r.Id,
                BrRacuna = r.BrRacuna,
                ImePrezime = r.ImePrezime,
                Adresa = r.Adresa,
                BrojTelefona = r.BrojTelefona,
                DatumPorudzbine = r.DatumPorudzbine,
                DatumIsporuke = r.DatumIsporuke,
                AparatZaKartice = r.AparatZaKartice,
                Lift = r.Lift,
                Stan = r.Stan,
                Napomena = r.Napomena,
                Status = r.Status,
                RadnikId = r.RadnikId,
                RadnikImePrezime = r.Radnik.ImePrezime,

                Stavke = r.Stavke
                .OrderBy(s => s.Rb)
                .Select(s => new UcitajStavkePorudzbineDTO
                {
                    Id = s.Id,
                    Rb = s.Rb,
                    Kolicina = s.Kolicina,
                    Boja = s.Boja,
                    Dimenzija = s.Dimenzija,
                    FinalnaCena = s.FinalnaCena,
                    Proizvod = new VratiSveProizvodeDTO
                    {
                        Id = s.Proizvod.Id,
                        Naziv = s.Proizvod.Naziv,
                        Cena = s.Proizvod.Cena
                    }
                }).ToList()
            };
            return porudzbina;

        }

        public async Task<bool> IzmeniPorudzbinu(int id, IzmeniPorudzbinuDTO dto)
        {
            var porudzbina = await dbContext.Porudzbine
                .Include(p => p.Stavke)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (porudzbina == null) return false;

            // 1) osnovna polja
            porudzbina.BrRacuna = dto.BrRacuna;
            porudzbina.ImePrezime = dto.ImePrezime;
            porudzbina.Adresa = dto.Adresa;
            porudzbina.BrojTelefona = dto.BrojTelefona;
            porudzbina.DatumIsporuke = dto.DatumIsporuke;
            porudzbina.DatumPorudzbine = dto.DatumPorudzbine;
            porudzbina.AparatZaKartice = dto.AparatZaKartice;
            porudzbina.Lift = dto.Lift;
            porudzbina.Stan = dto.Stan;
            porudzbina.Napomena = dto.Napomena;
            porudzbina.Status = dto.Status;

            // 2) brisanje (obavezno prvo)
            var dtoIds = dto.Stavke.Where(s => s.Id.HasValue).Select(s => s.Id!.Value).ToHashSet();
            var zaBrisanje = porudzbina.Stavke.Where(s => !dtoIds.Contains(s.Id)).ToList();

            dbContext.StavkePorudzbine.RemoveRange(zaBrisanje);

            // bitno: izbaci i iz navigacije da ne učestvuju u renumeraciji
            foreach (var del in zaBrisanje)
                porudzbina.Stavke.Remove(del);

            // 3) update postojećih (ne diraj Rb ovde)
            foreach (var sDto in dto.Stavke.Where(s => s.Id.HasValue))
            {
                var s = porudzbina.Stavke.FirstOrDefault(x => x.Id == sDto.Id!.Value);
                if (s == null) return false;

                s.Kolicina = sDto.Kolicina;
                s.Boja = sDto.Boja;
                s.Dimenzija = sDto.Dimenzija;
                s.FinalnaCena = sDto.FinalnaCena;
                s.ProizvodId = sDto.ProizvodId;
            }

            // 4) dodaj nove
            var nove = dto.Stavke
                .Where(s => !s.Id.HasValue)
                .Select(s => new StavkaPorudzbine
                {
                    Kolicina = s.Kolicina,
                    Boja = s.Boja,
                    Dimenzija = s.Dimenzija,
                    FinalnaCena = s.FinalnaCena,
                    ProizvodId = s.ProizvodId,
                    PorudzbinaId = porudzbina.Id,
                    Rb = 0 // dodelićemo posle
                })
                .ToList();

            await dbContext.StavkePorudzbine.AddRangeAsync(nove);

            // 5) RENumeracija bez pucanja unique indexa:
            // prvo svima daj privremene Rb (velike), snimi
            int tmp = 100000;
            foreach (var s in porudzbina.Stavke)
                s.Rb = tmp++;
            foreach (var s in nove)
                s.Rb = tmp++;

            await dbContext.SaveChangesAsync();

            // onda finalni Rb 1..N po redosledu iz DTO (Rb koji je došao sa klijenta)
            var dtoSorted = dto.Stavke.OrderBy(s => s.Rb).ToList();
            int rb = 1;

            foreach (var sDto in dtoSorted)
            {
                if (sDto.Id.HasValue)
                {
                    var ent = porudzbina.Stavke.First(x => x.Id == sDto.Id.Value);
                    ent.Rb = rb++;
                }
                else
                {
                    // mapiramo nove redom kako stižu (isti redosled kao u dtoSorted)
                    var ent = nove.First(n => n.ProizvodId == sDto.ProizvodId
                                           && n.Boja == sDto.Boja
                                           && n.Dimenzija == sDto.Dimenzija
                                           && Math.Abs(n.FinalnaCena - sDto.FinalnaCena) < 0.0001
                                           && n.Kolicina == sDto.Kolicina);
                    ent.Rb = rb++;
                    nove.Remove(ent); // da ne pogodi istu opet
                }
            }

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<string> GenerisiBrojRacuna(string lokal)
        {
            string prefix = lokal == "Piramida" ? "P" : "B";

            int currentYear = DateTime.Now.Year;
            int shortYear = currentYear % 100;

            // Uzimamo poslednju porudžbinu ISTOG lokala u TEKUĆOJ godini
            var poslednja = await dbContext.Porudzbine
                .Where(p => p.BrRacuna.StartsWith(prefix) &&
                            p.DatumPorudzbine.Year == currentYear)
                .OrderByDescending(p => p.Id)
                .FirstOrDefaultAsync();

            int redniBroj = 1;

            if (poslednja != null)
            {
                // poslednja.BrojRacuna npr "P32/25"
                var parts = poslednja.BrRacuna
                    .Replace(prefix, "")   // "32/25"
                    .Split('/');

                int poslednji = int.Parse(parts[0]);
                redniBroj = poslednji + 1;
            }

            return $"{prefix}{redniBroj}/{shortYear}";
        }

    }
        
    
}

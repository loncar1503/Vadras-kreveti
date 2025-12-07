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

        public async Task<List<UcitajSvePorudzbineDTO>> UcitajSvePorudzbine()
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

        public async Task<int?> KreirajPorudzbinu(KreirajPorudzbinuDTO dto)
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
                DatumPorudzbine = DateTime.Now,
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

            return porudzbina.Id;
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
        Proizvod = new UcitajSveProizvodeDTO
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

            if (porudzbina == null)
                return false;

            // ----------------------------
            // 1) Izmena osnovnih podataka
            // ----------------------------
            porudzbina.BrRacuna = dto.BrRacuna;
            porudzbina.ImePrezime = dto.ImePrezime;
            porudzbina.Adresa = dto.Adresa;
            porudzbina.BrojTelefona = dto.BrojTelefona;
            porudzbina.DatumIsporuke = dto.DatumIsporuke;
            porudzbina.AparatZaKartice = dto.AparatZaKartice;
            porudzbina.Lift = dto.Lift;
            porudzbina.Stan = dto.Stan;
            porudzbina.Napomena = dto.Napomena;
            porudzbina.Status = dto.Status;

            // ----------------------------
            // 2) Odredi koje stavke ostaju, menjaju se, brišu, dodaju
            // ----------------------------

            var dtoStavkeIds = dto.Stavke.Where(s => s.Id.HasValue).Select(s => s.Id.Value).ToList();

            // STARE STAVKE KOJE TREBA OBRISATI
            var stavkeZaBrisanje = porudzbina.Stavke
                .Where(s => !dtoStavkeIds.Contains(s.Id))
                .ToList();

            dbContext.StavkePorudzbine.RemoveRange(stavkeZaBrisanje);

            // ----------------------------
            // 3) Obradi postojeće stavke
            // ----------------------------
            foreach (var sDto in dto.Stavke.Where(s => s.Id.HasValue))
            {
                var s = porudzbina.Stavke.First(x => x.Id == sDto.Id.Value);

                s.Rb = sDto.Rb;
                s.Kolicina = sDto.Kolicina;
                s.Boja = sDto.Boja;
                s.Dimenzija = sDto.Dimenzija;
                s.FinalnaCena = sDto.FinalnaCena;
                s.ProizvodId = sDto.ProizvodId;
            }

            // ----------------------------
            // 4) Dodaj nove stavke
            // ----------------------------
            var noveStavke = dto.Stavke
                .Where(s => !s.Id.HasValue)
                .Select(s => new StavkaPorudzbine
                {
                    Rb = s.Rb,
                    Kolicina = s.Kolicina,
                    Boja = s.Boja,
                    Dimenzija = s.Dimenzija,
                    ProizvodId = s.ProizvodId,
                    FinalnaCena=s.FinalnaCena,
                    PorudzbinaId = porudzbina.Id
                })
                .ToList();

            await dbContext.StavkePorudzbine.AddRangeAsync(noveStavke);

            // ----------------------------
            // 5) Sačuvaj promene
            // ----------------------------
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
        
    
}

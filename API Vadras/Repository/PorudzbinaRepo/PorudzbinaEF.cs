using API_Vadras.DTO.Porudzbina;
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
        public async Task<int?> KreirajPorudzbinu(KreirajPorudzbinuDTO dto)
        {
            // jednostavne validacije u repou
            if (dto == null || dto.Stavke == null || !dto.Stavke.Any())
                return null;

            // da li radnik postoji
            var radnikPostoji = await dbContext.Radnici
                .AnyAsync(r => r.Id == dto.RadnikId);

            if (!radnikPostoji)
                return null;

            // provera dupliranog Rb unutar iste porudžbine
            var rbs = dto.Stavke.Select(s => s.Rb).ToList();
            if (rbs.Count != rbs.Distinct().Count())
                return null;

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

            foreach (var s in dto.Stavke)
            {
                var proizvod = new Proizvod
                {
                    Naziv = s.Naziv,
                    //Dimenzije = s.Dimenzije,
                    Cena = s.Cena
                };

                dbContext.Proizvodi.Add(proizvod);

                var stavka = new StavkaPorudzbine
                {
                    Rb = s.Rb,
                    Kolicina = s.Kolicina,
                    Boja = s.Boja,
                    Proizvod = proizvod,
                    Porudzbina = porudzbina
                };
                porudzbina.Stavke.Add(stavka);
            }

            dbContext.Porudzbine.Add(porudzbina);
            await dbContext.SaveChangesAsync();

            return porudzbina.Id;
        }
    }
}

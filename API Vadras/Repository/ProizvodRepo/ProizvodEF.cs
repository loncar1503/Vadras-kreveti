using API_Vadras.DTO.Proizvod;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace API_Vadras.Repository.ProizvodRepo
{
    public class ProizvodEF : IProizvod
    {
        private readonly VadrasDbContext dbContext;

        public ProizvodEF(VadrasDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Proizvod>> DodajVise(List<Proizvod> proizvodi)
        {
            dbContext.Proizvodi.AddRange(proizvodi);

            await dbContext.SaveChangesAsync();
            
            return proizvodi;
        }

        public async Task<List<Proizvod>> IzmeniVise(List<IzmeniProizvodDTO> proizvodi)
        {
            var ids = proizvodi.Select(x => x.Id).ToList();

            var ucitaniProizvodi = await dbContext.Proizvodi
                                          .Where(p => ids.Contains(p.Id))
                                          .ToListAsync();

            foreach (var dto in proizvodi)
            {
                var proizvod = ucitaniProizvodi.First(p => p.Id == dto.Id);

                proizvod.Naziv = dto.Naziv;
                //proizvod.Dimenzije = dto.Dimenzije;
                proizvod.Cena = dto.Cena;
            }

            await dbContext.SaveChangesAsync();

            return ucitaniProizvodi;
        }
    }
}

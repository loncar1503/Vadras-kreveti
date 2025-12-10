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

        public async Task<int> KreirajProizvod(KreirajProizvodDTO dto)
        {
            if(dto == null)
            {
                return 0;
            }
            var pr= new Proizvod { Cena = dto.Cena, Naziv=dto.Naziv };
            dbContext.Proizvodi.Add(pr);
            await dbContext.SaveChangesAsync();
            return pr.Id;
        }

        public async Task<List<Proizvod>> DodajVise(List<Proizvod> proizvodi)
        {
            dbContext.Proizvodi.AddRange(proizvodi);

            await dbContext.SaveChangesAsync();
            
            return proizvodi;
        }

        public async Task<Proizvod> IzmeniProizvod(int id, KreirajProizvodDTO dto)
        {
            var pr = await  dbContext.Proizvodi.FirstOrDefaultAsync(x => x.Id == id);
            if(pr== null)
            {
                return null;
            }
            pr.Naziv=dto.Naziv;
            pr.Cena=dto.Cena;
            await dbContext.SaveChangesAsync();
            return pr;
        }

        public async Task<bool> ObrisiProizvod(int id)
        {
            var proizvod=await dbContext.Proizvodi.FirstOrDefaultAsync(x => x.Id == id);
            if(proizvod == null)
            {
                return false;
            }
            dbContext.Proizvodi.Remove(proizvod);
            await dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<List<VratiSveProizvodeDTO>> VratiSveProizvode()
        {
            return await dbContext.Proizvodi
               .OrderBy(p => p.Naziv)
               .Select(p => new VratiSveProizvodeDTO
               {
                   Id = p.Id,
                   Naziv = p.Naziv,
                   Cena = p.Cena
               })
               .ToListAsync();
        }
    }
}

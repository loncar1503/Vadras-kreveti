using API_Vadras.DTO.Radnik;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace API_Vadras.Repository.RadniciRepo
{
    public class RadniciEF : IRadnici
    {
        private readonly VadrasDbContext dbContext;

        public RadniciEF(VadrasDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public  async Task<Radnik?> VratiRadnika(string username, string password)
        {
            var radnik = await dbContext.Radnici
        .FirstOrDefaultAsync(r =>
            r.Username == username &&
            r.Sifra == password);

            if (radnik == null)
                return null;
         return radnik;
        }
    }
}


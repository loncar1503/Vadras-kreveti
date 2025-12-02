
using API_Vadras.DTO.StavkaPorudzbine;
using Microsoft.EntityFrameworkCore;

namespace API_Vadras.Repository.StavkaPorudzbineRepo
{
    public class StavkaPorudzbineEF : IStavkaPorudzbine
    {
        private readonly VadrasDbContext dbContext;

        public StavkaPorudzbineEF(VadrasDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> IzmeniStavke(int porudzbinaId, List<IzmeniStavkePorudzbineDTO> dto)
        {
            if (dto == null || !dto.Any())
                return false;

            var ids = dto.Select(s => s.Id).ToList();

            var stavke = await dbContext.StavkePorudzbine
                .Where(s => s.PorudzbinaId == porudzbinaId && ids.Contains(s.Id))
                .ToListAsync();

            if (stavke.Count != dto.Count)
                return false;

            // provera duplikata Rb, ovo je neka luda provera ali mislim da mozemo ovo da 
            // izbegnemo ako odradimo dobru proveru pri slanju podataka
            var noviRbPoId = dto.ToDictionary(x => x.Id, x => x.Rb);

            var sviRb = stavke
                .Select(s => noviRbPoId.TryGetValue(s.Id, out var noviRb) ? noviRb : s.Rb)
                .ToList();

            if (sviRb.Count != sviRb.Distinct().Count())
                return false;

            // mapiranje dto → entitet
            foreach (var sDto in dto)
            {
                var ent = stavke.First(s => s.Id == sDto.Id);
                ent.Rb = sDto.Rb;
                ent.Kolicina = sDto.Kolicina;
                ent.Boja = sDto.Boja;
            }

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ObrisiStavke(int porudzbinaId, List<int> ids)
        {
            if (ids == null || !ids.Any())
                return false;

            var stavke = await dbContext.StavkePorudzbine
                .Where(s => s.PorudzbinaId == porudzbinaId && ids.Contains(s.Id))
                .ToListAsync();

            if (!stavke.Any())
                return false;

            dbContext.StavkePorudzbine.RemoveRange(stavke);

            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}

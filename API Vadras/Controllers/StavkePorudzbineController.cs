using API_Vadras.DTO.StavkaPorudzbine;
using API_Vadras.Repository.StavkaPorudzbineRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Vadras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StavkePorudzbineController : ControllerBase
    {
        private readonly IStavkaPorudzbine repo;

        public StavkePorudzbineController(IStavkaPorudzbine repo)
        {
            this.repo = repo;
        }

        [HttpDelete("obrisi-vise")]
        public async Task<IActionResult> ObrisiViseStavki([FromBody] ObrisiStavkePorudzbineDTO dto)
        {
            bool success = await repo.ObrisiStavke(dto.PorudzbinaId, dto.StavkeIds);

            return Ok(success);
        }

        [HttpPut("porudzbina/{porudzbinaId}")]
        public async Task<IActionResult> IzmeniStavke(int porudzbinaId,[FromBody] List<IzmeniStavkePorudzbineDTO> dto)
        {
            bool uspesno = await repo.IzmeniStavke(porudzbinaId, dto);

            return Ok(uspesno);
        }
    }
}

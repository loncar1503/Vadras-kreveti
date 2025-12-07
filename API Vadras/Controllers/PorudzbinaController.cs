using API_Vadras.DTO.Porudzbina;
using API_Vadras.Repository.PorudzbinaRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Vadras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PorudzbinaController : ControllerBase
    {

        private readonly IPorudzbina repo;

        public PorudzbinaController(IPorudzbina repo)
        {
            this.repo = repo;
        }

        [HttpPost("kreiraj-porudzbinu")]
        public async Task<IActionResult> KreirajPorudzbinu([FromBody] KreirajPorudzbinuDTO dto)
        {
            var id = await repo.KreirajPorudzbinu(dto);

            if (id is null)
                return BadRequest(false);

            return Ok(id);
        }

        [HttpGet("ucitaj-porudzbine")]
        public async Task<IActionResult> GetSvePorudzbine()
        {
            var porudzbine = await repo.UcitajSvePorudzbine();
            return Ok(porudzbine);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> ObrisiPorudzbinu(int id)
        {
            var uspeh = await repo.ObrisiPorudzbinu(id);
            return Ok(uspeh);
        }

        [HttpGet("vrati-porudzbinu")]
        public async Task<IActionResult> VratiPorudzbinu(int id)
        {
            var porudzbina = await repo.VratiPorudzbinu(id);
            return Ok(porudzbina);
        }

        [HttpPut("{id}/izmeni-porudzbinu")]
        public async Task<IActionResult> IzmeniPorudzbinuFull(int id,[FromBody] IzmeniPorudzbinuDTO dto)
        {
            var ok = await repo.IzmeniPorudzbinu(id, dto);
            return Ok(ok); 
        }
    }
}

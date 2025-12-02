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
        private readonly VadrasDbContext dbContext;
        private readonly IPorudzbina repo;

        public PorudzbinaController(IPorudzbina repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> KreirajPorudzbinu([FromBody] KreirajPorudzbinuDTO dto)
        {
            var id = await repo.KreirajPorudzbinu(dto);

            if (id is null)
                return BadRequest(false);

            return Ok(id);
        }
    }
}

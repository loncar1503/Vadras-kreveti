using API_Vadras.DTO.Radnik;
using API_Vadras.Repository.ApiKeyRepo;
using API_Vadras.Repository.RadniciRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Vadras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadniciController : ControllerBase
    {
        private readonly IRadnici repo;
        private readonly IApiKey repoKey;

        public RadniciController(IRadnici repo,IApiKey repoKey)
        {
            this.repo = repo;
            this.repoKey = repoKey;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] RadnikDTO dto)
        {

            var radnik = await repo.VratiRadnika(dto.Username, dto.Password);
            if (radnik == null)
                return Unauthorized("Neispravan username ili password");

            var apiKey = await repoKey.CreateAsync(radnik.Id, expireHours: 12);

            return Ok(new
            {
                apiKey = apiKey.Key,
                expiresAt = apiKey.ExpiresAt,
                Radnik=radnik
            });
        }
    }
}

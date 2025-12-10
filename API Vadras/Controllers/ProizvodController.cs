using API_Vadras.DTO.Proizvod;
using API_Vadras.Repository.ProizvodRepo;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Vadras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodController : ControllerBase
    {
        private readonly IProizvod repo;

        public ProizvodController(IProizvod repo)
        {
            this.repo = repo;
        }

        [HttpPost("dodaj-vise")]
        public async Task<IActionResult> DodajVise([FromBody] List<Proizvod> dtos)
        {
            var proizvodi = dtos.Select(x => new Proizvod
            {
                Naziv = x.Naziv,
                Cena = x.Cena,
                //Dimenzije=x.Dimenzije,
            }).ToList();

            var result = await repo.DodajVise(proizvodi);

            return Ok(result);
        }

        [HttpPut("izmeni-proizvod")]
        public async Task<IActionResult> IzmeniProizvod(int id,[FromBody] KreirajProizvodDTO dto)
        {
            var result = await repo.IzmeniProizvod(id,dto);
            return Ok(result);
        }

        [HttpGet("vrati-sve-proizvode")]
        public async Task<IActionResult> VratiSveProizvode()
        {
            var proizvodi = await repo.VratiSveProizvode();
            return Ok(proizvodi);
        }

        [HttpPost("kreiraj-proizvod")]
        public async Task<IActionResult> DodajProizvod([FromBody] KreirajProizvodDTO dto)
        {
            var result = await repo.KreirajProizvod(dto);

            return Ok(result);
        }

        [HttpDelete("obrisi-proizvod")]
        public async Task<IActionResult> ObrisiProizvod(int id)
        {
            var result = await repo.ObrisiProizvod(id);

            return Ok(result);
        }
    }
}

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
        public async Task<IActionResult> DodajVise([FromBody] List<KreirajProizvodDTO> dtos)
        {
            var proizvodi = dtos.Select(x=> new Proizvod 
            { 
            Naziv=x.Naziv,
            Cena=x.Cena,
            //Dimenzije=x.Dimenzije,
            }).ToList();
            
            var result = await repo.DodajVise(proizvodi);

            return Ok(result);
        }

        [HttpPut("izmeni-vise")]
        public async Task<IActionResult> IzmeniVise([FromBody] List<IzmeniProizvodDTO> dtos)
        {
            var result = await repo.IzmeniVise(dtos);
            return Ok(result);
        }

        [HttpGet("ucitaj-proizvode")]
        public async Task<IActionResult> GetAll()
        {
            var proizvodi = await repo.UcitajSveProizvode();
            return Ok(proizvodi);
        }
    }
}

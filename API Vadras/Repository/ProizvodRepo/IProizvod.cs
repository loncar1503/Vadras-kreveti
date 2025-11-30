using API_Vadras.DTO.Proizvod;
using Domain;

namespace API_Vadras.Repository.ProizvodRepo
{
    public interface IProizvod
    {
        Task<List<Proizvod>> DodajVise(List<Proizvod> proizvodi);
        Task<List<Proizvod>> IzmeniVise(List<IzmeniProizvodDTO> proizvodi);
    }
}

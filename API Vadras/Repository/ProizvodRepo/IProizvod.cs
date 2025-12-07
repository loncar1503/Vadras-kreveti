using API_Vadras.DTO.Proizvod;
using Domain;

namespace API_Vadras.Repository.ProizvodRepo
{
    public interface IProizvod
    {
        Task<List<Proizvod>> DodajVise(List<Proizvod> proizvodi);
        Task<Proizvod> IzmeniProizvod(int id,KreirajProizvodDTO dto);
        Task<List<UcitajSveProizvodeDTO>> UcitajSveProizvode();
        Task<bool> ObrisiProizvod(int id);
        Task<int> DodajProizvod(KreirajProizvodDTO dto);
    }
}

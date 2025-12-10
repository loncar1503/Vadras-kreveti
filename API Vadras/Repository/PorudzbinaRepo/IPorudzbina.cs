using API_Vadras.DTO.Porudzbina;

namespace API_Vadras.Repository.PorudzbinaRepo
{
    public interface IPorudzbina
    {
        Task<string> KreirajPorudzbinu(KreirajPorudzbinuDTO dto);
        Task<List<UcitajSvePorudzbineDTO>> VratiSvePorudzbine();
        Task<VratiPorudzbinuDTO>VratiPorudzbinu(int id);
        Task<bool> ObrisiPorudzbinu(int id);

        Task<string> GenerisiBrojRacuna(string lokal);

        Task<bool> IzmeniPorudzbinu(int id, IzmeniPorudzbinuDTO dto);


    }
}

using API_Vadras.DTO.Porudzbina;

namespace API_Vadras.Repository.PorudzbinaRepo
{
    public interface IPorudzbina
    {
        Task<int?> KreirajPorudzbinu(KreirajPorudzbinuDTO dto);
        Task<List<UcitajSvePorudzbineDTO>> UcitajSvePorudzbine();
        Task<VratiPorudzbinuDTO>VratiPorudzbinu(int id);
        Task<bool> ObrisiPorudzbinu(int id);

        Task<bool> IzmeniPorudzbinu(int id, IzmeniPorudzbinuDTO dto);


    }
}

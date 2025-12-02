using API_Vadras.DTO.Porudzbina;

namespace API_Vadras.Repository.PorudzbinaRepo
{
    public interface IPorudzbina
    {
        Task<int?> KreirajPorudzbinu(KreirajPorudzbinuDTO dto);
    }
}

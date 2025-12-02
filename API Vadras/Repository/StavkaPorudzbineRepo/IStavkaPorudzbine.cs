using API_Vadras.DTO.StavkaPorudzbine;

namespace API_Vadras.Repository.StavkaPorudzbineRepo
{
    public interface IStavkaPorudzbine
    {
        Task<bool> ObrisiStavke(int porudzbinaId, List<int> ids);
        Task<bool> IzmeniStavke(int porudzbinaId, List<IzmeniStavkePorudzbineDTO> dto);
    }
}

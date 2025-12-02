namespace API_Vadras.DTO.StavkaPorudzbine
{
    public class ObrisiStavkePorudzbineDTO
    {
        public int PorudzbinaId { get; set; }
        public List<int> StavkeIds { get; set; } = new();
    }
}

namespace API_Vadras.DTO.StavkaPorudzbine
{
    public class IzmeniStavkePorudzbineDTO
    {
        public int Id { get; set; }       
        public int Rb { get; set; }       
        public int Kolicina { get; set; }
        public string Boja { get; set; } = null!;
    }
}

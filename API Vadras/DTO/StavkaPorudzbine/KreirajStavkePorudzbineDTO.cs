namespace API_Vadras.DTO.StavkaPorudzbine
{
    public class KreirajStavkePorudzbineDTO
    {
        public int Rb { get; set; }
        public int Kolicina { get; set; }
        public string Boja { get; set; } = null!;

        // podaci za proizvod
        public string Naziv { get; set; } = null!;
        public string Dimenzije { get; set; } = null!;
        public double Cena { get; set; }
    }
}

using API_Vadras.DTO.Proizvod;

namespace API_Vadras.DTO.StavkaPorudzbine
{
    public class UcitajStavkePorudzbineDTO
    {
        public int Id { get; set; }
        public int Rb { get; set; }
        public int Kolicina { get; set; }
        public string Boja { get; set; } = null!;
        public double FinalnaCena { get; set; }
        public string Dimenzija { get; set; } = null!;   // iz stavke

        public UcitajSveProizvodeDTO Proizvod { get; set; }
    }
}

using API_Vadras.DTO.StavkaPorudzbine;

namespace API_Vadras.DTO.Porudzbina
{
    public class KreirajPorudzbinuDTO
    {
        public string BrRacuna { get; set; } = null!;
        public string ImePrezime { get; set; } = null!;
        public string Adresa { get; set; } = null!;
        public string BrojTelefona { get; set; } = null!;
        public DateTime DatumPorudzbine { get; set; }
        public DateTime DatumIsporuke { get; set; }
        public bool AparatZaKartice { get; set; }
        public bool Lift { get; set; }
        public bool Stan { get; set; }
        public string Napomena { get; set; } = null!;
        public int RadnikId { get; set; }
        public List<KreirajStavkePorudzbineDTO> Stavke { get; set; } = new();
    }
}

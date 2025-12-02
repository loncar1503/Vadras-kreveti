namespace API_Vadras.DTO.StavkaPorudzbine
{
    public class UcitajStavkePorudzbineDTO
    {
        public int Id { get; set; }
        public int Rb { get; set; }
        public int Kolicina { get; set; }
        public string Boja { get; set; } = null!;

        public string Dimenzija { get; set; } = null!;   // iz stavke

        public int ProizvodId { get; set; }
        public string NazivProizvoda { get; set; } = null!;
        public double Cena { get; set; }
    }
}

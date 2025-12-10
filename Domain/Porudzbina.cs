namespace Domain
{
    public enum Status
    {
        Zakazano,
        Isporuceno,
        Odlozeno
    }
    public class Porudzbina
    {
        public int Id { get; set; }
        public string BrRacuna { get; set; }
        public string ImePrezime { get; set; }
        public string? Radnja { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }
        public DateTime DatumPorudzbine { get; set; }
        public DateTime DatumIsporuke { get; set; }
        public bool AparatZaKartice { get; set; }
        public bool Lift { get; set; }
        public bool Stan { get; set; }
        public string Napomena { get; set; }
        public Status Status { get; set; }
        // Veza ka radniku koji je napravio porudžbinu
        public int RadnikId { get; set; }
        public Radnik Radnik { get; set; } = null!;

        // Veza ka stavkama
        public List<StavkaPorudzbine> Stavke { get; set; } = new();
    }
}

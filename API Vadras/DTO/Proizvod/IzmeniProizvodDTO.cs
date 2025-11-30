namespace API_Vadras.DTO.Proizvod
{
    public class IzmeniProizvodDTO
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = null!;
        public string Dimenzije { get; set; } = null!;
        public double Cena { get; set; }
    }
}

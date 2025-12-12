using API_Vadras.DTO.Proizvod;

namespace API_Vadras.DTO.StavkaPorudzbine
{
    public class IzmeniStavkePorudzbineDTO
    {
        public int? Id { get; set; }       
        public int Rb { get; set; }
        public string? ProizvodNaziv { get; set; }

        public int Kolicina { get; set; }
        public string Boja { get; set; } = null!;
        public string Dimenzija { get; set; }
        public double FinalnaCena { get; set; }
        public int ProizvodId { get; set; }


    }
}

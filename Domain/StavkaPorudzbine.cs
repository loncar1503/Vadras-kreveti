using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class StavkaPorudzbine
    {
        public int Id { get; set; }

        public int Rb { get; set; }
        public int Kolicina { get; set; }
        public string Boja { get; set; } = null!;

        public int PorudzbinaId { get; set; }
        public Porudzbina Porudzbina { get; set; } = null!;

        public int ProizvodId { get; set; }
        public Proizvod Proizvod { get; set; } = null!;
    }
}

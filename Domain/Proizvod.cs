using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Proizvod
    {
        public int Id { get; set; }

        public string Naziv { get; set; } = null!;
        public string Dimenzije { get; set; } = null!;
        public double Cena { get; set; }
    }
}

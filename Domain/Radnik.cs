using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Radnik
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;
        public string Sifra { get; set; } = null!;     

        public string ImePrezime { get; set; } = null!;

        public List<Porudzbina> Porudzbine { get; set; } = new();
    }
}

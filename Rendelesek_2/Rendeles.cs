using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendelesek_2
{
    class Rendeles
    {
        public char Tipus { get; set; }
        public DateTime Datum { get; set; }
        public int RendelesSzam { get; set; }
        public string Email { get; set; }
        public bool Varakozo { get; set; }
        public int MegrendelesOsszesen { get; set; }

        public Rendeles(string sor)
        {
            List<string> adatok = sor.Split(';').ToList();
            Tipus = char.Parse(adatok[0]);
            Datum = DateTime.Parse(adatok[1]);
            RendelesSzam = int.Parse(adatok[2]);
            Email = adatok[3];
        }
    }
}

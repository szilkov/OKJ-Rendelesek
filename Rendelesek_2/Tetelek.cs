using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendelesek_2
{
    class Tetelek
    {
        public char Tipus { get; set; }
        public int RendelesSzam { get; set; }
        public string Cikkszam { get; set; }
        public int Mennyiseg { get; set; }
        public int  TetelekOsszesen { get; set; }

        public Tetelek(string sor)
        {
            List<string> adatok = sor.Split(';').ToList();
            Tipus = char.Parse(adatok[0]);
            RendelesSzam = int.Parse(adatok[1]);
            Cikkszam = adatok[2];
            Mennyiseg = int.Parse(adatok[3]);
        }
    }
}

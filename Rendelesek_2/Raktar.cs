using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendelesek_2
{
    class Raktar
    {
        public string Kod { get; set; }
        public string Nev { get; set; }
        public int Ar { get; set; }
        public int Keszlet { get; set; }
        public int HianyzoMennyiseg { get; set; }

        public Raktar(string sor)
        {
            List<string> adatok = sor.Split(';').ToList();
            Kod = adatok[0];
            Nev = adatok[1];
            Ar = int.Parse(adatok[2]);
            Keszlet =int.Parse( adatok[3]);
        }

    }
}

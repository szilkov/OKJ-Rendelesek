using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Rendelesek_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> raktarSorai = File.ReadAllLines("raktar.csv", Encoding.UTF8).ToList();
            List<Raktar> raktarkeszlet = new List<Raktar>();

            foreach (string item in raktarSorai)
            {
                raktarkeszlet.Add(new Raktar(item));
            }

            List<string> megrendelesekSorai = File.ReadAllLines("rendeles.csv", Encoding.UTF8).ToList();
            List<Rendeles> megrendelesek = new List<Rendeles>();
            List<Tetelek> tetelek = new List<Tetelek>();
            char rendelesTipus = 'M';
            

            foreach (string item in megrendelesekSorai)
            {
                if(item[0]==rendelesTipus)
                {
                    megrendelesek.Add(new Rendeles(item));

                }
                else
                {
                    tetelek.Add(new Tetelek(item));
                }
                
            }
           

            string level = String.Empty;

            for (int i = 0; i < megrendelesek.Count; i++)
            {
                

                for (int j = 0; j < tetelek.Count; j++)
                {
                    if (megrendelesek[i].RendelesSzam == tetelek[j].RendelesSzam)
                    {
                        for (int l = 0; l < raktarkeszlet.Count; l++)
                        {
                            if (tetelek[j].Cikkszam == raktarkeszlet[l].Kod && tetelek[j].Mennyiseg > raktarkeszlet[l].Keszlet)
                            {
                                megrendelesek[i].Varakozo = true;
                                break;

                            }
                            else
                            {

                                megrendelesek[i].Varakozo = false;

                            }



                        }
                        for (int l = 0; l < raktarkeszlet.Count; l++)
                        {
                            if (!megrendelesek[i].Varakozo && tetelek[j].Cikkszam == raktarkeszlet[l].Kod)
                            {
                                raktarkeszlet[l].Keszlet = raktarkeszlet[l].Keszlet - tetelek[j].Mennyiseg;
                                tetelek[j].TetelekOsszesen = tetelek[j].Mennyiseg * raktarkeszlet[l].Ar;

                            }

                        }
                        megrendelesek[i].MegrendelesOsszesen += tetelek[j].TetelekOsszesen;
                    }
                }
                if(!megrendelesek[i].Varakozo)
                {
                    level += $"{megrendelesek[i].Email.ToString()};A rendelése függő állapotba került. Hamarosan értesítjük a kiszállításról."+Environment.NewLine;
                }else
                {
                    level += $"{megrendelesek[i].Email.ToString()}; A rendelését két napon belül szállítjuk.  A rendelés összértéke: {megrendelesek[i].MegrendelesOsszesen} Ft" +Environment.NewLine;
                }
            }

            using(StreamWriter kiiras = new StreamWriter("level.txt", false, Encoding.UTF8))
            {
                kiiras.WriteLine(level);
            }

           
            for (int l = 0; l < raktarkeszlet.Count; l++)
            {
                int osszesTetel = 0;
                for (int j = 0; j < tetelek.Count; j++)
                {
                    if(raktarkeszlet[l].Kod == tetelek[j].Cikkszam)
                    {
                        osszesTetel += tetelek[j].Mennyiseg;
                    }
                    
                    
                }
                raktarkeszlet[l].HianyzoMennyiseg = osszesTetel - raktarkeszlet[l].Keszlet ;
            }
            using(StreamWriter beszerzes = new StreamWriter("beszerzes.csv", false, Encoding.UTF8))
            {

                foreach (Raktar item in raktarkeszlet)
                {
                    if (item.HianyzoMennyiseg > 0)
                    {
                        beszerzes.WriteLine($"{item.Kod};{item.HianyzoMennyiseg}");
                    }
                }

            }

           
                Console.ReadKey();



        }
    }
}

using System;

using Zadanie1;

namespace Zadanie2
{
    public class GrafObiektow 
    {
        public void Wypelnij(Kolekcje kolekcje)
        {
            KlasaA obiektA = null;
            KlasaB obiektB = null;
            KlasaC obiektC = null;
            
            obiektA = new KlasaA(10.2f, "NapisA", new DateTime(2019, 11, 25), obiektB);
            obiektC = new KlasaC(0.1f, "NapisC", new DateTime(2019, 10, 10), obiektA);
            obiektB = new KlasaB(22.2f, "NapisB", new DateTime(2019, 12, 06), obiektC);
            
            obiektA.Obiekt = obiektB;

            kolekcje.Obiekty.Add(obiektA);
            kolekcje.Obiekty.Add(obiektB);
            kolekcje.Obiekty.Add(obiektC);
        }

        public string Wyswietl(Kolekcje kolekcje)
        {
            string tmp = "";

            tmp += "\nObiekty:\n";
            
            foreach (object o in kolekcje.Obiekty)
                tmp += o.ToString() + "\n";
            
            return tmp;
        }
    }
}

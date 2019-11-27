using System;

using Zadanie1;

namespace Zadanie2
{
    public class GrafObiektow 
    {
        public void Wypelnij(Kolekcje kolekcje)
        {
            kolekcje.ObiektA = null;
            kolekcje.ObiektB = null;
            kolekcje.ObiektC = null;

            kolekcje.ObiektA = new KlasaA(10.2f, "NapisA", new DateTime(2019, 11, 25), kolekcje.ObiektB);
            kolekcje.ObiektC = new KlasaC(0.1f, "NapisC", new DateTime(2019, 10, 10), kolekcje.ObiektA);
            kolekcje.ObiektB = new KlasaB(22.2f, "NapisB", new DateTime(2019, 12, 06), kolekcje.ObiektC);

            kolekcje.ObiektA.Obiekt = kolekcje.ObiektB;
        }

        public string Wyswietl(Kolekcje kolekcje)
        {
            return kolekcje.ToString();
        }
    }
}

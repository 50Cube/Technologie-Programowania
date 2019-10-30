using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class Zwrot : Zdarzenie
    {
        public Zwrot(Wykaz osoba, OpisStanu ksiazka, DateTime zwrot)
            : base(zwrot)
        {
            this.Osoba = osoba;
            this.Ksiazka = ksiazka;
        }

        public Wykaz Osoba { get; }
        public OpisStanu Ksiazka { get; }
        public override string ToString()
        {
            string[] tekst = { "Zwrot IdOsoba:", Osoba.Id.ToString(), " IdKsiazka:", Ksiazka.Katalog.Id.ToString(), " ", Data.ToString() };
            return string.Concat(tekst);
        }
    }
}

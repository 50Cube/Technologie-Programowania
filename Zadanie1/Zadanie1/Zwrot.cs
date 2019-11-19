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

        public Wykaz Osoba { get; set; }
        public OpisStanu Ksiazka { get; set; }
        public override string ToString()
        {
            string[] tekst = { "Zwrot ID Osoby: ", Osoba.Id.ToString(), ", ID Ksiazki: ", Ksiazka.Katalog.Id.ToString(), ", data zwrotu: ", Data.ToString() };
            return string.Concat(tekst);
        }
    }
}

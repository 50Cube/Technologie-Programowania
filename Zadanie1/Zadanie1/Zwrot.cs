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
        {
            this.osoba = osoba;
            this.ksiazka = ksiazka;
            this.Data = zwrot;
        }

        public Wykaz osoba { get; }
        public OpisStanu ksiazka { get; }
    }
}

using System;

namespace Zadanie1
{
    public class Zdarzenie
    {
        public Zdarzenie(Wykaz osoba, OpisStanu ksiazka, DateTime wypozyczenie)
        {
            this.osoba = osoba;
            this.ksiazka = ksiazka;
            this.dataWypozyczenia = wypozyczenie;
        }

        public Wykaz osoba { get; }
        public OpisStanu ksiazka { get; }
        public DateTime dataWypozyczenia { get; }
        public DateTime? dataZwrotu { get; set; } = null; // ? - mark a value type as nullable
    }
}

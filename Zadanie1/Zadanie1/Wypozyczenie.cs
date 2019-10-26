using System;

namespace Zadanie1
{
    public class Wypozyczenie : Zdarzenie
    {
        public Wypozyczenie(Wykaz osoba, OpisStanu ksiazka, DateTime wypozyczenie)
        {
            this.osoba = osoba;
            this.ksiazka = ksiazka;
            this.Data = wypozyczenie;
        }

        public Wykaz osoba { get; }
        public OpisStanu ksiazka { get; }
    }
}

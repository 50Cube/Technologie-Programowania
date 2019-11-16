using System;

namespace Zadanie1
{
    public class Wypozyczenie : Zdarzenie
    {
        public Wypozyczenie(Wykaz osoba, OpisStanu ksiazka, DateTime wypozyczenie)
            : base(wypozyczenie)
        {
            this.Osoba = osoba;
            this.Ksiazka = ksiazka;
        }

        public Wykaz Osoba { get; set; }
        public OpisStanu Ksiazka { get; set; }
        public override string ToString()
        {
            string[] tekst = {"Wypozycznie IdOsoba:",Osoba.Id.ToString()," IdKsiazka:",Ksiazka.Katalog.Id.ToString()," ",Data.ToString()};
            return string.Concat(tekst);
        }
    }
}

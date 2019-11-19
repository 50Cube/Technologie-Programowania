using System;
using System.Runtime.Serialization;

namespace Zadanie1
{
    [Serializable]
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
            string[] tekst = {"Wypozycznie ID Osoby: ",Osoba.Id.ToString(),", ID Ksiazki: ",Ksiazka.Katalog.Id.ToString(),", data wypożyczenia: ",Data.ToString()};
            return string.Concat(tekst);
        }

        override public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Osoba", this.Osoba);
            info.AddValue("Ksiazka", this.Ksiazka);
        }
    }
}

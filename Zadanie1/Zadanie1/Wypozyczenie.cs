using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
namespace Zadanie1
{
    [Serializable]
    public class Wypozyczenie : Zdarzenie
    {
        [JsonConstructor]
        public Wypozyczenie(Wykaz osoba, OpisStanu ksiazka, DateTime wypozyczenie)
            : base(wypozyczenie)
        {
            this.Osoba = osoba;
            this.Ksiazka = ksiazka;
            this.opisID = ksiazka.Katalog.Id;
            this.klientID = osoba.Id;
        }

        public Wypozyczenie(SerializationInfo info, StreamingContext context)
            :base(info,context)
        {
            this.opisID = (int)info.GetValue("OpisID", typeof(int));
            this.klientID = (int)info.GetValue("KlientID", typeof(int));
            //           this.Osoba = (Wykaz)info.GetValue("Osoba", typeof(Wykaz));
            //          this.Ksiazka = (OpisStanu)info.GetValue("Ksiazka", typeof(OpisStanu));
        }
        public int klientID;
        public int opisID;
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
            //       info.AddValue("Osoba", this.Osoba,typeof(Wykaz));
            //       info.AddValue("Ksiazka", this.Ksiazka,typeof(OpisStanu));
            info.AddValue("KlientID", this.Osoba.Id, typeof(int));
            info.AddValue("OpisID", this.Ksiazka.Katalog.Id, typeof(int));

        }
    }
}

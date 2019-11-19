using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Zadanie1
{
    [Serializable]
    public class Zwrot : Zdarzenie, ISerializable
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

        override public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Osoba", this.Osoba);
            info.AddValue("Ksiazka", this.Ksiazka);
        }

    }
}

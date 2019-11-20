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
            this.opisID = ksiazka.Katalog.Id;
            this.klientID = osoba.Id;
        }

        public Zwrot(SerializationInfo info, StreamingContext context)
      : base(info, context)
        {
            this.opisID = (int)info.GetValue("OpisID", typeof(int));
            this.klientID = (int)info.GetValue("KlientID", typeof(int));
        }
        public int klientID;
        public int opisID;
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
            info.AddValue("KlientID", this.Osoba.Id, typeof(int));
            info.AddValue("OpisID", this.Ksiazka.Katalog.Id, typeof(int));
        }

    }
}

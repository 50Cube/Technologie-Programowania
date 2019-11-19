using System;
using System.Runtime.Serialization;
namespace Zadanie1
{
    [Serializable]
    public class OpisStanu : ISerializable
    {
        public OpisStanu(Katalog ksiazka, int ilosc, double cena, DateTime data)
        {
            this.Katalog = ksiazka;
            this.Ilosc = ilosc;
            this.Cena = cena;
            this.DataZakupu = data;
        }

        public Katalog Katalog { get; set; }
        public int Ilosc { get; set; }
        public double Cena { get; set; }
        public DateTime DataZakupu { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Katalog", this.Katalog);
            info.AddValue("Ilosc", this.Ilosc);
            info.AddValue("Cena", this.Cena);
            info.AddValue("DataZakupu", this.DataZakupu);
        }

        public override string ToString()
        {
            return "Katalog o ID: " + this.Katalog.Id + ", ilość sztuk: " + this.Ilosc + ", cena: " + this.Cena + ", data zakupu: " + this.DataZakupu;
        }
    }
}

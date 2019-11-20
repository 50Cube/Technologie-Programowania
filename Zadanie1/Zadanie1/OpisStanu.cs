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
            this.KatalogID = ksiazka.Id;
        }
        public OpisStanu(SerializationInfo info, StreamingContext context)
        {
            this.KatalogID = (int)info.GetValue("KatalogID", typeof(int)); //Katalog ustawiony pozniej            
            this.Ilosc = (int)info.GetValue("Ilosc", typeof(int));
            this.Cena = (double)info.GetValue("Cena", typeof(double));
      //      this.DataZakupu = (DateTime)info.GetValue("DataZakupu", typeof(DateTime));

        }
        public int KatalogID { get; set;}
        public Katalog Katalog { get; set; }
        public int Ilosc { get; set; }
        public double Cena { get; set; }
        public DateTime DataZakupu { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("KatalogID", this.Katalog.Id,typeof(int));
            info.AddValue("Ilosc", this.Ilosc,typeof(int));
            info.AddValue("Cena", this.Cena,typeof(double));
   //         info.AddValue("DataZakupu", this.DataZakupu,typeof(DateTime));
        }

        public override string ToString()
        {
            return "Katalog o ID: " + this.Katalog.Id + ", ilość sztuk: " + this.Ilosc + ", cena: " + this.Cena + ", data zakupu: " + this.DataZakupu;
        }
    }
}

using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
namespace Zadanie1
{
    [Serializable]
    public class OpisStanu : ISerializable
    {

        [JsonConstructor]
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
            string data = (string)info.GetValue("DataZakupu", typeof(string));
            try
            {
                this.DataZakupu = DateTime.ParseExact(data, "dd/MM/yyyy HH:mm:ss", null);
            }
            catch (System.FormatException)
            {
                this.DataZakupu = DateTime.ParseExact(data, "MM/dd/yyyy HH:mm:ss", null);
            }
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
            info.AddValue("DataZakupu", this.DataZakupu,typeof(String));
        }

        public override string ToString()
        {
            return "Katalog o ID: " + this.Katalog.Id + ", ilość sztuk: " + this.Ilosc + ", cena: " + this.Cena + ", data zakupu: " + this.DataZakupu;
        }
    }
}

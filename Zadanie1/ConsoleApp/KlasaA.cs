using System;
using System.Runtime.Serialization;
namespace Zadanie2
{
    public class KlasaA : ISerializable
    {
        public KlasaA() { }

        public KlasaA(float liczba, string napis, DateTime data, KlasaB obiekt)
        {
            this.Liczba = liczba;
            this.Napis = napis;
            this.Data = data;
            this.Obiekt = obiekt;
        }

        public KlasaA(SerializationInfo info, StreamingContext context)
        {
            Liczba = (float) info.GetValue("Liczba", typeof(float));
            Napis = (string) info.GetValue("Napis", typeof(string));
            Data = (DateTime) info.GetValue("Data", typeof(DateTime));
            Obiekt = (KlasaB)info.GetValue("Obiekt", typeof(KlasaB));
        }

        public float Liczba { get; set; }
        public string Napis { get; set; }
        public DateTime Data { get; set; }
        public KlasaB Obiekt { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Liczba", this.Liczba);
            info.AddValue("Napis", this.Napis);
            info.AddValue("Data", this.Data);
            info.AddValue("Obiekt", this.Obiekt);
        }

        public override string ToString()
        {
            return "Liczba: " + this.Liczba + ", Napis: " + this.Napis + ", Data: " + this.Data;
        }
    }
}

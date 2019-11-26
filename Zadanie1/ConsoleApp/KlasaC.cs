using System;
using Newtonsoft.Json;
namespace Zadanie2
{
    public class KlasaC
    {
        public KlasaC() { }
        public KlasaC(float liczba, string napis, DateTime data, KlasaA obiekt)
        {
            this.Liczba = liczba;
            this.Napis = napis;
            this.Data = data;
            this.Obiekt = obiekt;
        }

        public float Liczba { get; set; }
        public string Napis { get; set; }
        public DateTime Data { get; set; }
        public KlasaA Obiekt { get; set; }

        public override string ToString()
        {
            return "Liczba: " + this.Liczba + ", Napis: " + this.Napis + ", Data: " + this.Data;
        }
    }
}

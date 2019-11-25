using System;

namespace Zadanie2
{
    public class KlasaB
    {
        public KlasaB(float liczba, string napis, DateTime data, KlasaC obiekt)
        {
            this.Liczba = liczba;
            this.Napis = napis;
            this.Data = data;
            this.Obiekt = obiekt;
        }

        public float Liczba { get; set; }
        public string Napis { get; set; }
        public DateTime Data { get; set; }
        public KlasaC Obiekt { get; set; }

        public override string ToString()
        {
            return "Liczba: " + this.Liczba + ", Napis: " + this.Napis + ", Data: " + this.Data;
        }
    }
}

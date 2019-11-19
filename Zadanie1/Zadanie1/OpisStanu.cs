using System;

namespace Zadanie1
{
    public class OpisStanu
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

        public override string ToString()
        {
            return "Katalog o ID: " + this.Katalog.Id + ", ilość sztuk: " + this.Ilosc + ", cena: " + this.Cena + ", data zakupu: " + this.DataZakupu;
        }
    }
}

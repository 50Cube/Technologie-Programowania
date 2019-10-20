using System;

namespace Zadanie1
{
    public class OpisStanu
    {
        public OpisStanu(Katalog ksiazka, int ilosc, double cena, DateTime data)
        {
            this.katalog = ksiazka;
            this.ilosc = ilosc;
            this.cena = cena;
            this.dataZakupu = data;
        }

        public Katalog katalog { get; }
        public int ilosc { get; set; }
        public double cena { get; set; }
        public DateTime dataZakupu { get; }
    }
}

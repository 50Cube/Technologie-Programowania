using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class Autor
    {
        public Autor(string imie, string nazwisko)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
        }

        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public override string ToString() => "Imie: " + this.Imie + ", Nazwisko: " + this.Nazwisko;
    }
}

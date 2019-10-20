using System;
using Zadanie1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Wykaz osoba1 = new Wykaz(2137, "Gabor", "Nowag");
            Console.WriteLine(osoba1.id);
            osoba1.id = 997;
            Console.WriteLine(osoba1.id);

            Wykaz osoba = new Wykaz(1, "Norbert", "Gierczak");
            Autor autor = new Autor("Henryk", "Sienkiewicz");
            Katalog katalog = new Katalog(autor, "Krzyzacy", 2019);
            OpisStanu opis = new OpisStanu(katalog, 1, 29.99, new DateTime(2019, 10, 20));
            Zdarzenie zdarzenie = new Zdarzenie(osoba, opis, new DateTime(2019, 10, 20));
            Console.WriteLine("Null" + zdarzenie.dataZwrotu.ToString());
            zdarzenie.dataZwrotu = new DateTime(2019, 10, 21,10,10,10);
            Console.WriteLine("Nie null " + zdarzenie.dataZwrotu.ToString());
            Console.Read();
        }
    }
}

using System;
using Zadanie1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Wykaz osoba1 = new Wykaz(2137, "Gabor", "Nowag");
            Console.WriteLine(osoba1.Id);
            osoba1.Id = 997;
            Console.WriteLine(osoba1.Id);

            Wykaz osoba = new Wykaz(1, "Norbert", "Gierczak");
            Autor autor = new Autor("Henryk", "Sienkiewicz");
            Katalog katalog = new Katalog(1, autor, "Krzyzacy", 2019);
            OpisStanu opis = new OpisStanu(katalog, 1, 29.99, new DateTime(2019, 10, 20));
            Wypozyczenie zdarzenie = new Wypozyczenie(osoba, opis, new DateTime(2019, 10, 20));
            Console.WriteLine("Null" + zdarzenie.Data.ToString());

            DataRepository dr = new DataRepository(new WypelnianieLosowymi());
            Console.WriteLine(dr.GetAllWykaz().Count);
            Console.Read();
        }
    }
}

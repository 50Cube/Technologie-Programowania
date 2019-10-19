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
            Console.Write(osoba1.id);
            Console.Read();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Console.Write(osoba1.Id);
            Console.Read();
        }
    }
}

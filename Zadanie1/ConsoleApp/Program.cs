using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie1;

namespace Zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            int wybor = 0;

            GrafObiektow grafObiektow = new GrafObiektow();
            DataContext dataContext = new DataContext();
            grafObiektow.Wypelnij(dataContext);

            Console.WriteLine("Wybierz funkcje programu");
            Console.WriteLine("1 - zapisz dane do pliku");
            Console.WriteLine("2 - wczytaj dane z pliku");
            Console.WriteLine("3 - zakoncz program");
            
            OperacjeJSON.Zapisz(dataContext);
            

            DataContext dataContext2 = new DataContext();
            OperacjeJSON.Wczytaj(dataContext2);

            //OperacjeJSON.Zapisz(dataContext2);
            Console.Read();

        }
    }
}

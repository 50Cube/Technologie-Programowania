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
            DataContext dataContext = new DataContext();
            while (true)
            {
                do
                {
                    Console.WriteLine("Wybierz funkcje programu");
                    Console.WriteLine("1 - stwórz testowy graf obiektów");
                    Console.WriteLine("2 - zapisz dane do pliku");
                    Console.WriteLine("3 - wczytaj dane z pliku");
                    Console.WriteLine("4 - zakoncz program");
                    try
                    {
                        wybor = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Nieprawidlowy format");
                    }
                    Console.WriteLine(wybor);
                } while (wybor < 0 || wybor > 4);

                switch (wybor)
                {
                    case 1:
                        GrafObiektow grafObiektow = new GrafObiektow();
                        grafObiektow.Wypelnij(dataContext);
                        break;
                    case 2:
                        OperacjeJSON.Zapisz(dataContext);
                        break;
                    case 3:
                        dataContext = new DataContext();
                        OperacjeJSON.Wczytaj(dataContext);
                        break;
                    case 4:
                        System.Environment.Exit(1);
                        break;
                }
            }
        }
    }
}

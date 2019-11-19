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
            GrafObiektow grafObiektow = new GrafObiektow();
            while (true)
            {
                do
                {
                    Console.WriteLine("Wybierz funkcje programu");
                    Console.WriteLine("1 - stwórz testowy graf obiektów");
                    Console.WriteLine("2 - zapisz dane do pliku JSON");
                    Console.WriteLine("3 - wczytaj dane z pliku JSON");
                    Console.WriteLine("4 - zapisz dane do pliku CSV");
                    Console.WriteLine("5 - wczytaj dane z pliku CSV");
                    Console.WriteLine("6 - wyświetl graf obiektow");
                    Console.WriteLine("7 - zakoncz program");
                    try
                    {
                        wybor = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Nieprawidlowy format");
                    }
                    Console.WriteLine(wybor);
                } while (wybor < 0 || wybor > 7);

                switch (wybor)
                {
                    case 1:
                        grafObiektow = new GrafObiektow();
                        grafObiektow.Wypelnij(dataContext);
                        Console.WriteLine("Pomyślnie utworzono graf obiektów");
                        break;
                    case 2:
                        OperacjeJSON.Zapisz(dataContext);
                        Console.WriteLine("Pomyślnie zapisano dane do pliku");
                        break;
                    case 3:
                        dataContext = new DataContext();
                        OperacjeJSON.Wczytaj(dataContext);
                        Console.WriteLine("Pomyślnie wczytane dane z pliku");
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        Console.WriteLine(grafObiektow.Wyswietl(dataContext));
                        break;
                    case 7:
                        System.Environment.Exit(1);
                        break;
                }
            }
        }
    }
}

using System;

namespace Zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            int wybor = 0;
            Kolekcje kolekcje = new Kolekcje();
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
                    Console.WriteLine("7 - zakończ program");
                    try
                    {
                        wybor = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Nieprawidlowy format");
                    }
                } while (wybor < 0 || wybor > 7);

                switch (wybor)
                {
                    case 1:
                        grafObiektow = new GrafObiektow();
                        kolekcje = new Kolekcje();
                        grafObiektow.Wypelnij(kolekcje);
                        Console.WriteLine("Pomyślnie utworzono graf obiektów");
                        break;
                    case 2:
                        OperacjeJSON.Zapisz(kolekcje);
                        Console.WriteLine("Pomyślnie zapisano dane do pliku .json");
                        break;
                    case 3:
                        kolekcje = new Kolekcje();
                        kolekcje = OperacjeJSON.Wczytaj();
                        Console.WriteLine("Pomyślnie wczytane dane z pliku .json");
                        break;
                    case 4:
                        OperacjeCSV.Zapisz(kolekcje);
                        Console.WriteLine("Pomyślnie zapisano dane do pliku .csv");
                        break;
                    case 5:
                        kolekcje = new Kolekcje();
                        kolekcje = OperacjeCSV.Wczytaj();
                        Console.WriteLine("Pomyślnie wczytane dane z pliku .csv");
                        break;
                    case 6:
                        Console.WriteLine(grafObiektow.Wyswietl(kolekcje));
                        break;
                    case 7:
                        System.Environment.Exit(1);
                        break;
                }
            }
        }
    }
}

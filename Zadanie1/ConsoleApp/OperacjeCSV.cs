using System.IO;
using System.Text;

namespace Zadanie2
{
    public class OperacjeCSV
    {
        public static void Zapisz(Kolekcje kolekcje)
        {
            if (File.Exists("Kolekcje.csv"))
                File.Delete("Kolekcje.csv");

        }

        public static void Wczytaj(Kolekcje kolekcje)
        {
            CSVFormatter<Kolekcje> formatterCSV = new CSVFormatter<Kolekcje>();
            string line;
            StreamReader file = new System.IO.StreamReader("Kolekcje.csv");

            file.Close();

        }
    }
}

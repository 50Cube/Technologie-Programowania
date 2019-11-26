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
            
                Stream s = new FileStream("Kolekcje.csv", FileMode.Append, FileAccess.Write);
                CSVFormatter<Kolekcje> formatter = new CSVFormatter<Kolekcje>();
                formatter.Serialize(s, kolekcje);
                s.Close();
            
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

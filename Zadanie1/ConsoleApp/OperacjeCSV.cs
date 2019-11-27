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
                CSVFormatter formatter = new CSVFormatter();
                formatter.Serialize(s, kolekcje.ObiektA);
                s.Close();
            
        }

        public static void Wczytaj(Kolekcje kolekcje)
        {
            CSVFormatter formatterCSV = new CSVFormatter();
            Stream s = new FileStream("Kolekcje.csv", FileMode.Open, FileAccess.Read);
            formatterCSV.Deserialize(s);
            StreamReader file = new System.IO.StreamReader("Kolekcje.csv");

            file.Close();

        }
    }
}

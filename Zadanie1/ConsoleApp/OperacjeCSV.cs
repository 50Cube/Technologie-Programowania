using System.IO;
using System.Text;

namespace Zadanie2
{
    public class OperacjeCSV
    {
        public static void Zapisz(Kolekcje kolekcje)
        {
            if (File.Exists("Kolekcje.csv"))
            {
                File.Delete("Kolekcje.csv");
            }
            Stream s = new FileStream("Kolekcje.csv", FileMode.Append, FileAccess.Write);
                CSVFormatter formatter = new CSVFormatter();
                formatter.Serialize(s, kolekcje);
                s.Close();
            
        }

        public static Kolekcje Wczytaj()
        {
            CSVFormatter formatterCSV = new CSVFormatter();
            Stream s = new FileStream("Kolekcje.csv", FileMode.Open, FileAccess.Read);
            Kolekcje k = (Kolekcje)formatterCSV.Deserialize(s);
            s.Close();
            return k;

        }
    }
}

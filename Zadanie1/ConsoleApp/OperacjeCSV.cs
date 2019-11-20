using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Zadanie1;

namespace Zadanie2
{
    public class OperacjeCSV 
    {
        private static StringBuilder stringBuilder = new StringBuilder();

        public static void Zapisz(DataContext data)
        {
            if (File.Exists("Wykazy.csv"))
                File.Delete("Wykazy.csv");
            foreach (Wykaz w in data.ElementyWykazu)
            {
                Stream s = new FileStream("Wykazy.csv", FileMode.Append, FileAccess.Write);
                CSVFormatter<Wykaz> formatter = new CSVFormatter<Wykaz>();
                formatter.Serialize(s,w);
                s.Close();
            }

            if (File.Exists("Katalogi.csv"))
                File.Delete("Katalogi.csv");
            foreach (Katalog k in data.Katalogi.Values)
            {
                Stream s = new FileStream("Katalogi.csv", FileMode.Append, FileAccess.Write);
                CSVFormatter<Katalog> formatter = new CSVFormatter<Katalog>();
                formatter.Serialize(s, k);
                s.Close();
            }

            if (File.Exists("OpisyStanu.csv"))
                File.Delete("OpisyStanu.csv");
            foreach (OpisStanu o in data.OpisyStanu)
            {
                Stream s = new FileStream("OpisyStanu.csv", FileMode.Append, FileAccess.Write);
                CSVFormatter<OpisStanu> formatter = new CSVFormatter<OpisStanu>();
                formatter.Serialize(s, o);
                s.Close();
            }

            if (File.Exists("Zdarzenia.csv"))
                File.Delete("Zdarzenia.csv");
            foreach (Zdarzenie z in data.Zdarzenia)
            {
                Stream s = new FileStream("Zdarzenia.csv", FileMode.Append, FileAccess.Write);
                CSVFormatter<Zdarzenie> formatter = new CSVFormatter<Zdarzenie>();
                formatter.Serialize(s, z);
                s.Close();
            }
            /*foreach (Wykaz w in data.ElementyWykazu)
                stringBuilder.AppendLine(string.Join(Delimiter,w.Id, w.Imie, w.Nazwisko));
            System.IO.File.WriteAllText("Wykazy.csv", stringBuilder.ToString());

            stringBuilder = new StringBuilder();
            foreach (Katalog k in data.Katalogi.Values)
                stringBuilder.AppendLine(string.Join(Delimiter, k.Id, k.Autor.Imie, k.Autor.Nazwisko, k.Tytul, k.RokWydania));
            System.IO.File.WriteAllText("Katalogi.csv", stringBuilder.ToString());

            stringBuilder = new StringBuilder();
            foreach (OpisStanu o in data.OpisyStanu)
                stringBuilder.AppendLine(string.Join(Delimiter, o.Katalog.Id, o.Ilosc, o.Cena, o.DataZakupu));
            System.IO.File.WriteAllText("OpisyStanu.csv", stringBuilder.ToString());
            */
            //stringBuilder = new StringBuilder();
            //foreach (Zdarzenie z in data.Zdarzenia)
            //    stringBuilder.AppendLine(string.Join(Delimiter, ));
            //System.IO.File.WriteAllText("Zdarzenia.csv", stringBuilder.ToString());
        }

        public static void Wczytaj(DataContext data)
        {
            CSVFormatter<Wykaz> formatterCSVwykaz = new CSVFormatter<Wykaz>();
            string line;
            StreamReader fileWykaz = new System.IO.StreamReader("Wykazy.csv");
            while ((line = fileWykaz.ReadLine()) != null)
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(line);
                MemoryStream stream = new MemoryStream(byteArray);
                Wykaz obj = (Wykaz)formatterCSVwykaz.Deserialize(stream);
                data.ElementyWykazu.Add(obj);
            }
            fileWykaz.Close();

            CSVFormatter<Katalog> formatterCSVkatalog = new CSVFormatter<Katalog>();
            StreamReader fileKatalog = new System.IO.StreamReader("Katalogi.csv");
            while ((line = fileKatalog.ReadLine()) != null)
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(line);
                MemoryStream stream = new MemoryStream(byteArray);
                Katalog obj = (Katalog)formatterCSVkatalog.Deserialize(stream);
                data.Katalogi.Add(obj.Id,obj);
            }
            fileKatalog.Close();

            //CSVFormatter<OpisStanu> formatterCSVopis = new CSVFormatter<OpisStanu>();
            //StreamReader fileOpis = new System.IO.StreamReader("OpisyStanu.csv");
            //while ((line = fileOpis.ReadLine()) != null)
            //{
            //    byte[] byteArray = Encoding.ASCII.GetBytes(line);
            //    MemoryStream stream = new MemoryStream(byteArray);
            //    OpisStanu obj = (OpisStanu)formatterCSVopis.Deserialize(stream);
            //    data.OpisyStanu.Add(obj);
            //}
            //fileOpis.Close();
        }
    }
}

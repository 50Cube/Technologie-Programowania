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

            if (File.Exists("Zwroty.csv"))
                File.Delete("Zwroty.csv");
            if (File.Exists("Wypozyczenia.csv"))
                File.Delete("Wypozyczenia.csv");
            foreach (Zdarzenie z in data.Zdarzenia)
            {
                Stream s = new FileStream("Zwroty.csv", FileMode.Append, FileAccess.Write);
                Stream s2 = new FileStream("Wypozyczenia.csv", FileMode.Append, FileAccess.Write);

                CSVFormatter<Zwrot> formatter = new CSVFormatter<Zwrot>();
                CSVFormatter<Wypozyczenie> formatter2 = new CSVFormatter<Wypozyczenie>();
                if(z.GetType() == typeof(Zwrot))
                {
                    formatter.Serialize(s, z);
                }
                else
                {
                    formatter.Serialize(s2, z);
                }
                s.Close();
                s2.Close();
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

            CSVFormatter<OpisStanu> formatterCSVopis = new CSVFormatter<OpisStanu>();
            StreamReader fileOpis = new System.IO.StreamReader("OpisyStanu.csv");
            while ((line = fileOpis.ReadLine()) != null)
            {
               byte[] byteArray = Encoding.ASCII.GetBytes(line);
                MemoryStream stream = new MemoryStream(byteArray);
                OpisStanu obj = (OpisStanu)formatterCSVopis.Deserialize(stream);
                obj.Katalog = data.Katalogi[obj.KatalogID];
                data.OpisyStanu.Add(obj);
            }
            fileOpis.Close();

            CSVFormatter<Zwrot> formatterCSVzwrot = new CSVFormatter<Zwrot>();
            StreamReader fileZwrot = new System.IO.StreamReader("Zwroty.csv");
            while ((line = fileZwrot.ReadLine()) != null)
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(line);
                MemoryStream stream = new MemoryStream(byteArray);
                Zwrot obj = (Zwrot)formatterCSVzwrot.Deserialize(stream);
                foreach(OpisStanu os in data.OpisyStanu)
                {
                    if (os.Katalog.Id == obj.opisID)
                    {
                        obj.Ksiazka = os;
                        break;
                    }
                }
                foreach (Wykaz os in data.ElementyWykazu)
                {
                    if (os.Id == obj.klientID)
                    {
                        obj.Osoba = os;
                        break;
                    }
                }
                data.Zdarzenia.Add(obj);
            }
            fileZwrot.Close();
            
            CSVFormatter<Wypozyczenie> formatterCSVWypozyczenie = new CSVFormatter<Wypozyczenie>();
            StreamReader fileWypozyczenie = new System.IO.StreamReader("Wypozyczenia.csv");
            while ((line = fileWypozyczenie.ReadLine()) != null)
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(line);
                MemoryStream stream = new MemoryStream(byteArray);
                Wypozyczenie obj = (Wypozyczenie)formatterCSVWypozyczenie.Deserialize(stream);
                foreach (OpisStanu os in data.OpisyStanu)
                {
                    if (os.Katalog.Id == obj.opisID)
                    {
                        obj.Ksiazka = os;
                        break;
                    }
                }
                foreach (Wykaz os in data.ElementyWykazu)
                {
                    if (os.Id == obj.klientID)
                    {
                        obj.Osoba = os;
                        break;
                    }
                }
                data.Zdarzenia.Add(obj);
            }
            fileWypozyczenie.Close();
            
        }
    }
}

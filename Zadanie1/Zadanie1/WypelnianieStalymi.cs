using System;

namespace Zadanie1
{
    public class WypelnianieStalymi : IWypelnianie
    {
        public WypelnianieStalymi() { }
        
        public void Wypelnij (DataContext dataContext)
        {
            dataContext.ElementyWykazu.Add(new Wykaz(1, "Emil", "Badura"));
            dataContext.ElementyWykazu.Add(new Wykaz(2, "Norbert", "Gierczak"));
            dataContext.ElementyWykazu.Add(new Wykaz(3, "Marcin", "Krasucki"));
            dataContext.ElementyWykazu.Add(new Wykaz(4, "Jan", "Nowak"));
            dataContext.ElementyWykazu.Add(new Wykaz(5, "Kamil", "Chrabąszcz"));


            dataContext.Katalogi.Add(1, new Katalog(1, new Autor("Henryk", "Sienkiewicz"), "Potop", 1886));
            dataContext.Katalogi.Add(2, new Katalog(2, new Autor("Henryk", "Sienkiewicz"), "W pustyni i w puszczy", 1912));
            dataContext.Katalogi.Add(3, new Katalog(3, new Autor("Bolesław", "Prus"), "Lalka", 1890));
            dataContext.Katalogi.Add(4, new Katalog(4, new Autor("Stefan", "Żeromski"), "Ludzie bezdomni", 1900));
            dataContext.Katalogi.Add(5, new Katalog(5, new Autor("Władysław", "Reymont"), "Chłopi", 1904));
            dataContext.Katalogi.Add(6, new Katalog(6, new Autor("Witold", "Gombrowicz"), "Ferdydurke", 1937));
            dataContext.Katalogi.Add(7, new Katalog(7, new Autor("Adam", "Mickiewicz"), "Dziady", 1822));
            dataContext.Katalogi.Add(8, new Katalog(8, new Autor("Aleksander", "Fredro"), "Zemsta", 1838));
            dataContext.Katalogi.Add(9, new Katalog(9, new Autor("Eliza", "Orzeszkowa"), "Nad Niemnem", 1888));
            dataContext.Katalogi.Add(10, new Katalog(10, new Autor("Zofia", "Nałkowska"), "Granica", 1935));


            dataContext.OpisyStanu.Add(new OpisStanu(dataContext.Katalogi[1], 5, 20.0, new DateTime(2019, 10, 20)));
            dataContext.OpisyStanu.Add(new OpisStanu(dataContext.Katalogi[2], 25, 30.0, new DateTime(2019, 10, 22)));
            dataContext.OpisyStanu.Add(new OpisStanu(dataContext.Katalogi[3], 10, 50.0, new DateTime(2019, 10, 21)));
            dataContext.OpisyStanu.Add(new OpisStanu(dataContext.Katalogi[4], 1, 25.0, new DateTime(2019, 10, 16)));
            dataContext.OpisyStanu.Add(new OpisStanu(dataContext.Katalogi[5], 0, 29.99, new DateTime(2019, 10, 18)));
            dataContext.OpisyStanu.Add(new OpisStanu(dataContext.Katalogi[6], 30, 20.0, new DateTime(2019, 09, 28)));
            dataContext.OpisyStanu.Add(new OpisStanu(dataContext.Katalogi[7], 100, 10.0, new DateTime(2019, 10, 03)));
            dataContext.OpisyStanu.Add(new OpisStanu(dataContext.Katalogi[8], 2, 80.0, new DateTime(2019, 10, 12)));
            dataContext.OpisyStanu.Add(new OpisStanu(dataContext.Katalogi[9], 17, 18.0, new DateTime(2019, 10, 11)));
            dataContext.OpisyStanu.Add(new OpisStanu(dataContext.Katalogi[10], 3, 45.0, new DateTime(2019, 09, 22)));


            dataContext.Zdarzenia.Add(new Wypozyczenie(dataContext.ElementyWykazu[0], dataContext.OpisyStanu[0], new DateTime(2019, 10, 20)));
            dataContext.Zdarzenia.Add(new Wypozyczenie(dataContext.ElementyWykazu[0], dataContext.OpisyStanu[3], new DateTime(2019, 10, 20)));
            dataContext.Zdarzenia.Add(new Wypozyczenie(dataContext.ElementyWykazu[1], dataContext.OpisyStanu[1], new DateTime(2019, 10, 20)));
            dataContext.Zdarzenia.Add(new Wypozyczenie(dataContext.ElementyWykazu[2], dataContext.OpisyStanu[2], new DateTime(2019, 10, 20)));
            dataContext.Zdarzenia.Add(new Wypozyczenie(dataContext.ElementyWykazu[3], dataContext.OpisyStanu[4], new DateTime(2019, 10, 20)));
            dataContext.Zdarzenia.Add(new Wypozyczenie(dataContext.ElementyWykazu[4], dataContext.OpisyStanu[5], new DateTime(2019, 10, 20)));
            dataContext.Zdarzenia.Add(new Wypozyczenie(dataContext.ElementyWykazu[4], dataContext.OpisyStanu[8], new DateTime(2019, 10, 20)));
            dataContext.Zdarzenia.Add(new Zwrot(dataContext.ElementyWykazu[0], dataContext.OpisyStanu[3], new DateTime(2019, 11, 02)));
        }
    }
}

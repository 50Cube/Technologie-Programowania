using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Zadanie1
{
    public class WypelnianieStalymi : IWypelnianie
    {
        public WypelnianieStalymi() { }
        
        public void wypelnij (DataContext dataContext)
        {
            dataContext.elementyWykazu.Add(new Wykaz(1, "Emil", "Badura"));
            dataContext.elementyWykazu.Add(new Wykaz(2, "Norbert", "Gierczak"));
            dataContext.elementyWykazu.Add(new Wykaz(3, "Marcin", "Krasucki"));
            dataContext.elementyWykazu.Add(new Wykaz(4, "Jan", "Nowak"));
            dataContext.elementyWykazu.Add(new Wykaz(5, "Kamil", "Chrabąszcz"));


            dataContext.katalogi.Add(1, new Katalog(new Autor("Henryk", "Sienkiewicz"), "Potop", 1886));
            dataContext.katalogi.Add(2, new Katalog(new Autor("Henryk", "Sienkiewicz"), "W pustyni i w puszczy", 1912));
            dataContext.katalogi.Add(3, new Katalog(new Autor("Bolesław", "Prus"), "Lalka", 1890));
            dataContext.katalogi.Add(4, new Katalog(new Autor("Stefan", "Żeromski"), "Ludzie bezdomni", 1900));
            dataContext.katalogi.Add(5, new Katalog(new Autor("Władysław", "Reymont"), "Chłopi", 1904));
            dataContext.katalogi.Add(6, new Katalog(new Autor("Witold", "Gombrowicz"), "Ferdydurke", 1937));
            dataContext.katalogi.Add(7, new Katalog(new Autor("Adam", "Mickiewicz"), "Dziady", 1822));
            dataContext.katalogi.Add(8, new Katalog(new Autor("Aleksander", "Fredro"), "Zemsta", 1838));
            dataContext.katalogi.Add(9, new Katalog(new Autor("Eliza", "Orzeszkowa"), "Nad Niemnem", 1888));
            dataContext.katalogi.Add(10, new Katalog(new Autor("Zofia", "Nałkowska"), "Granica", 1935));



            dataContext.opisyStanu.Add(new OpisStanu(dataContext.katalogi[0], 5, 20.0, new DateTime(2019, 10, 20)));
            dataContext.opisyStanu.Add(new OpisStanu(dataContext.katalogi[1], 25, 30.0, new DateTime(2019, 10, 22)));
            dataContext.opisyStanu.Add(new OpisStanu(dataContext.katalogi[2], 10, 50.0, new DateTime(2019, 10, 21)));
            dataContext.opisyStanu.Add(new OpisStanu(dataContext.katalogi[3], 1, 25.0, new DateTime(2019, 10, 16)));
            dataContext.opisyStanu.Add(new OpisStanu(dataContext.katalogi[4], 0, 29.99, new DateTime(2019, 10, 18)));
            dataContext.opisyStanu.Add(new OpisStanu(dataContext.katalogi[5], 30, 20.0, new DateTime(2019, 09, 28)));
            dataContext.opisyStanu.Add(new OpisStanu(dataContext.katalogi[6], 100, 10.0, new DateTime(2019, 10, 03)));
            dataContext.opisyStanu.Add(new OpisStanu(dataContext.katalogi[7], 2, 80.0, new DateTime(2019, 10, 12)));
            dataContext.opisyStanu.Add(new OpisStanu(dataContext.katalogi[8], 17, 18.0, new DateTime(2019, 10, 11)));
            dataContext.opisyStanu.Add(new OpisStanu(dataContext.katalogi[9], 3, 45.0, new DateTime(2019, 09, 22)));


            dataContext.zdarzenia.Add(new Zdarzenie(dataContext.elementyWykazu[0], dataContext.opisyStanu[0], new DateTime(2019, 10, 20)));
            dataContext.zdarzenia.Add(new Zdarzenie(dataContext.elementyWykazu[0], dataContext.opisyStanu[3], new DateTime(2019, 10, 20)));
            dataContext.zdarzenia.Add(new Zdarzenie(dataContext.elementyWykazu[1], dataContext.opisyStanu[1], new DateTime(2019, 10, 20)));
            dataContext.zdarzenia.Add(new Zdarzenie(dataContext.elementyWykazu[2], dataContext.opisyStanu[2], new DateTime(2019, 10, 20)));
            dataContext.zdarzenia.Add(new Zdarzenie(dataContext.elementyWykazu[3], dataContext.opisyStanu[4], new DateTime(2019, 10, 20)));
            dataContext.zdarzenia.Add(new Zdarzenie(dataContext.elementyWykazu[4], dataContext.opisyStanu[5], new DateTime(2019, 10, 20)));
            dataContext.zdarzenia.Add(new Zdarzenie(dataContext.elementyWykazu[4], dataContext.opisyStanu[8], new DateTime(2019, 10, 20)));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;
using Zadanie2;

namespace Tests2
{
    [TestClass]
    public class OperationsCSVtest
    {
        [TestMethod]
        public void TestSerializeWykaz()
        {
            DataContext dataContext = new DataContext();
            DataContext dataContext2 = new DataContext();
            GrafObiektow graf = new GrafObiektow();
            graf.Wypelnij(dataContext);

            OperacjeCSV.Zapisz(dataContext);
            OperacjeCSV.Wczytaj(dataContext2);

            Assert.AreEqual(dataContext.ElementyWykazu[1].Id, dataContext2.ElementyWykazu[1].Id);
            Assert.AreEqual(dataContext.ElementyWykazu[1].Imie, dataContext2.ElementyWykazu[1].Imie);
            Assert.AreEqual(dataContext.ElementyWykazu[1].Nazwisko, dataContext2.ElementyWykazu[1].Nazwisko);
        }

        [TestMethod]
        public void TestSerializeKatalog()
        {
            DataContext dataContext = new DataContext();
            DataContext dataContext2 = new DataContext();
            GrafObiektow graf = new GrafObiektow();
            graf.Wypelnij(dataContext);

            OperacjeCSV.Zapisz(dataContext);
            OperacjeCSV.Wczytaj(dataContext2);

            Assert.AreEqual(dataContext.Katalogi[1].Autor.Imie, dataContext2.Katalogi[1].Autor.Imie);
            Assert.AreEqual(dataContext.Katalogi[1].Autor.Nazwisko, dataContext2.Katalogi[1].Autor.Nazwisko);
            Assert.AreEqual(dataContext.Katalogi[1].Id, dataContext2.Katalogi[1].Id);
            Assert.AreEqual(dataContext.Katalogi[1].Tytul, dataContext2.Katalogi[1].Tytul);
            Assert.AreEqual(dataContext.Katalogi[1].RokWydania, dataContext2.Katalogi[1].RokWydania);
        }

        [TestMethod]
        public void TestSerializeOpisStanu()
        {
            DataContext dataContext = new DataContext();
            DataContext dataContext2 = new DataContext();
            GrafObiektow graf = new GrafObiektow();
            graf.Wypelnij(dataContext);

            OperacjeCSV.Zapisz(dataContext);
            OperacjeCSV.Wczytaj(dataContext2);

            Assert.AreEqual(dataContext.OpisyStanu[1].Katalog.Id, dataContext2.OpisyStanu[1].Katalog.Id);
            Assert.AreEqual(dataContext.OpisyStanu[1].KatalogID, dataContext2.OpisyStanu[1].KatalogID);
            Assert.AreEqual(dataContext.OpisyStanu[1].Ilosc, dataContext2.OpisyStanu[1].Ilosc);
            Assert.AreEqual(dataContext.OpisyStanu[1].DataZakupu, dataContext2.OpisyStanu[1].DataZakupu);
        }

        [TestMethod]
        public void TestSerializeZdarzenie()
        {
            DataContext dataContext = new DataContext();
            DataContext dataContext2 = new DataContext();
            GrafObiektow graf = new GrafObiektow();
            graf.Wypelnij(dataContext);

            OperacjeCSV.Zapisz(dataContext);
            OperacjeCSV.Wczytaj(dataContext2);

            Assert.AreEqual(dataContext.Zdarzenia.Count, dataContext2.Zdarzenia.Count);
        }
    }
}

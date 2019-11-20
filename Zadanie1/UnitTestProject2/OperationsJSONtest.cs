using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;
using Zadanie2;

namespace Tests2
{
    [TestClass]
    public class OperationsJSONtest
    {
        [TestMethod]
        public void TestSerializeWykaz()
        {
            DataContext dataContext = new DataContext();
            DataContext dataContext2 = new DataContext();
            GrafObiektow graf = new GrafObiektow();
            graf.Wypelnij(dataContext);

            OperacjeJSON.Zapisz(dataContext);
            OperacjeJSON.Wczytaj(dataContext2);

            Assert.AreEqual(dataContext.ElementyWykazu[1].Id, dataContext2.ElementyWykazu[1].Id);
            Assert.AreEqual(dataContext.ElementyWykazu[1].Imie, dataContext2.ElementyWykazu[1].Imie);
            Assert.AreEqual(dataContext.ElementyWykazu[1].Nazwisko, dataContext2.ElementyWykazu[1].Nazwisko);
            Assert.AreEqual(dataContext.ElementyWykazu.Count, dataContext2.ElementyWykazu.Count);
        }

        [TestMethod]
        public void TestSerializeKatalog()
        {
            DataContext dataContext = new DataContext();
            DataContext dataContext2 = new DataContext();
            GrafObiektow graf = new GrafObiektow();
            graf.Wypelnij(dataContext);

            OperacjeJSON.Zapisz(dataContext);
            OperacjeJSON.Wczytaj(dataContext2);

            Assert.AreEqual(dataContext.Katalogi[1].Autor.Imie, dataContext2.Katalogi[1].Autor.Imie);
            Assert.AreEqual(dataContext.Katalogi[1].Autor.Nazwisko, dataContext2.Katalogi[1].Autor.Nazwisko);
            Assert.AreEqual(dataContext.Katalogi[1].Id, dataContext2.Katalogi[1].Id);
            Assert.AreEqual(dataContext.Katalogi[1].Tytul, dataContext2.Katalogi[1].Tytul);
            Assert.AreEqual(dataContext.Katalogi[1].RokWydania, dataContext2.Katalogi[1].RokWydania);
            Assert.AreEqual(dataContext.Katalogi.Count, dataContext2.Katalogi.Count);
        }

        [TestMethod]
        public void TestSerializeOpisStanu()
        {
            DataContext dataContext = new DataContext();
            DataContext dataContext2 = new DataContext();
            GrafObiektow graf = new GrafObiektow();
            graf.Wypelnij(dataContext);

            OperacjeJSON.Zapisz(dataContext);
            OperacjeJSON.Wczytaj(dataContext2);

            Assert.AreEqual(dataContext.OpisyStanu[0].Cena, dataContext2.OpisyStanu[0].Cena);
            Assert.AreEqual(dataContext.OpisyStanu[0].DataZakupu, dataContext2.OpisyStanu[0].DataZakupu);
            Assert.AreEqual(dataContext.OpisyStanu[0].Ilosc, dataContext2.OpisyStanu[0].Ilosc);
            Assert.AreEqual(dataContext.OpisyStanu[0].Katalog.Id, dataContext2.OpisyStanu[0].Katalog.Id);
            Assert.AreEqual(dataContext.OpisyStanu.Count, dataContext2.OpisyStanu.Count);
        }

        [TestMethod]
        public void TestSerializeZdarzenie()
        {
            DataContext dataContext = new DataContext();
            DataContext dataContext2 = new DataContext();
            GrafObiektow graf = new GrafObiektow();
            graf.Wypelnij(dataContext);

            OperacjeJSON.Zapisz(dataContext);
            OperacjeJSON.Wczytaj(dataContext2);

            Assert.AreEqual(dataContext.Zdarzenia[1].GetType(), dataContext2.Zdarzenia[1].GetType());
            Assert.AreEqual(dataContext.Zdarzenia[1].Data, dataContext2.Zdarzenia[1].Data);
            Assert.AreEqual(dataContext.Zdarzenia.Count, dataContext2.Zdarzenia.Count);
        }
    }
}

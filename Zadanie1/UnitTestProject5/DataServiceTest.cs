using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace Tests
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void TestGetAutor()
        {
            DataRepository dR = new DataRepository(new WypelnianieStalymi());
            DataService dS = new DataService(dR);
            Assert.AreEqual(dS.GetAutor(dS.GetKatalog(1)).Nazwisko, "Sienkiewicz");
        }

        [TestMethod]
        public void TestGetAllZdarzenie()
        {
            DataRepository dR = new DataRepository(new WypelnianieStalymi());
            DataService dS = new DataService(dR);
            Assert.AreEqual(dS.GetAllZdarzenie().Count, 8);
        }

        [TestMethod]
        public void TestGetZdarzenie()
        {
            DataRepository dR = new DataRepository(new WypelnianieStalymi());
            DataService dS = new DataService(dR);
            Wypozyczenie wyp = new Wypozyczenie(dS.GetWykaz(1), dS.GetOpisStanu(dS.GetKatalog(1)), new DateTime(2019, 10, 20));
            Assert.AreEqual(dS.GetZdarzenie(1).GetType(), wyp.GetType());
        }

        [TestMethod]
        public void TestGetZdarzeniaPomiedzy()
        {
            DataRepository dR = new DataRepository(new WypelnianieStalymi());
            DataService dS = new DataService(dR);
            Assert.AreEqual(dS.GetZdarzeniaPomiedzy(new DateTime(2019, 10, 23), new DateTime(2019, 10, 25)).Count, 3);
        }

        [TestMethod]
        public void TestGetWypozyczeniaDlaWykazu()
        {
            DataRepository dR = new DataRepository(new WypelnianieStalymi());
            DataService dS = new DataService(dR);
            Assert.AreEqual(dS.GetWypozyczeniaDlaWykazu(dS.GetWykaz(1)).Count, 2);
        }

        [TestMethod]
        public void TestWypozycz()
        {
            DataRepository dR = new DataRepository(new WypelnianieStalymi());
            DataService dS = new DataService(dR);
            Katalog k = dS.GetKatalog(1);
            int iloscPrzed = dS.GetOpisStanu(k).Ilosc;
            dS.Wypozycz(dS.GetWykaz(1), k);
            int iloscPo = dS.GetOpisStanu(k).Ilosc;
            Assert.AreEqual(iloscPo + 1, iloscPrzed);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"Brak ksiazki do wypozyczenia")]
        public void TestWypozyczBrakKsiazki()
        {
            DataRepository dR = new DataRepository(new WypelnianieStalymi());
            DataService dS = new DataService(dR);
            Katalog k = dS.GetKatalog(1);
            dS.GetOpisStanu(k).Ilosc = 0;
            dS.Wypozycz(dS.GetWykaz(1), k);
        }

        [TestMethod]
        public void TestZwroc()
        {
            DataRepository dR = new DataRepository(new WypelnianieStalymi());
            DataService dS = new DataService(dR);
            Katalog k = dS.GetKatalog(1);
            int iloscPrzed = dS.GetOpisStanu(k).Ilosc;
            dS.Zwroc(dS.GetWykaz(1), k);
            int iloscPo = dS.GetOpisStanu(k).Ilosc;
            Assert.AreEqual(iloscPo - 1, iloscPrzed);
        }

        [TestMethod]
        public void TestGetZdarzeniaLog()
        {
            DataRepository dR = new DataRepository(new WypelnianieStalymi());
            Wypozyczenie wyp = new Wypozyczenie(dR.GetWykaz(1), dR.GetOpisStanu(dR.GetKatalog(1)), new DateTime(2019, 10, 20));
            dR.AddWypozyczenie(wyp);
            DataService dS = new DataService(dR);
            Assert.AreEqual(1, dS.GetZdarzeniaLog().Count);
        }
    }
}

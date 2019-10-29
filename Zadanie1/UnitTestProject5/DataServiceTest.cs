using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace DataServiceTest
{
    [TestClass]
    public class DataServiceTest
    {
        
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
    }
}

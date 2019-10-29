using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace DataRepositoryTest
{
    [TestClass]
    public class DataRepositoryTest
    {
        [TestMethod]
        public void TestGetAllWykaz()
        {
            DataRepository dr = new DataRepository(new WypelnianieStalymi());
            Assert.AreEqual(dr.GetAllWykaz().Count, 5);
        }

        [TestMethod]
        public void TestAddWykaz()
        {
            DataRepository dr = new DataRepository(new WypelnianieLosowymi());
            Assert.AreEqual(dr.GetAllWykaz().Count, 10);
            dr.AddWykaz(new Wykaz(20, "Oskar", "Tuszyński"));
            Assert.AreEqual(dr.GetAllWykaz().Count, 11);
        }

        [TestMethod]
        public void TestGetWykaz()
        {
            DataRepository dr = new DataRepository(new WypelnianieStalymi());
            Assert.AreEqual(dr.GetWykaz(2).Imie, "Norbert");
        }

        [TestMethod]
        public void TestUpdateWykaz()
        {
            DataRepository dr = new DataRepository(new WypelnianieStalymi());
            Assert.AreEqual(dr.GetWykaz(2).Imie, "Norbert");
            dr.UpdateWykaz(2, "Marcin", "Majkut");
            Assert.AreEqual(dr.GetWykaz(2).Imie, "Marcin");
            Assert.ThrowsException<Exception>(() => dr.UpdateWykaz(20, "Marcin", "Majkut"));
        }

        [TestMethod]
        public void TestDeleteWykaz()
        {
            DataRepository dr = new DataRepository(new WypelnianieStalymi());
            Assert.AreEqual(dr.GetAllWykaz().Count, 5);
            dr.DeleteWykaz(dr.GetWykaz(1));
            Assert.AreEqual(dr.GetAllWykaz().Count, 4);
        }


        [TestMethod]
        public void TestAddKatalog()
        {
            DataRepository dr = new DataRepository(new WypelnianieStalymi());
            Assert.AreEqual(dr.GetAllKatalog().Count, 10);
            dr.AddKatalog(new Katalog(11, new Autor("Henryk", "Sienkiewicz"), "Quo Vadis", 1896));
            Assert.AreEqual(dr.GetAllKatalog().Count, 11);
        }

        [TestMethod]
        public void TestGetKatalog()
        {
            DataRepository dr = new DataRepository(new WypelnianieStalymi());
            Assert.AreEqual(dr.GetKatalog(1).Tytul, "Potop");
        }

        [TestMethod]
        public void TestGetAllKatalog()
        {
            DataRepository dr = new DataRepository(new WypelnianieStalymi());
            Assert.AreEqual(dr.GetAllKatalog().Count, 10);
        }

        [TestMethod]
        public void TestUpdateKatalog()
        {
            DataRepository dr = new DataRepository(new WypelnianieStalymi());
            Assert.AreEqual(dr.GetKatalog(1).Tytul, "Potop");
            Autor autor = new Autor("Henryk", "Sienkiewicz");
            dr.UpdateKatalog(1, autor, "Powodz", 1886);
            Assert.AreEqual(dr.GetKatalog(1).Tytul, "Powodz");
        }

        [TestMethod]
        public void TestDeleteKatalog()
        {
            DataRepository dr = new DataRepository(new WypelnianieStalymi());
            Assert.AreEqual(dr.GetAllKatalog().Count, 10);
            dr.DeleteKatalog(1);
            Assert.AreEqual(dr.GetAllKatalog().Count, 9);
        }

        // testy CRUD zdarzenia

        [TestMethod]
        public void TestGetAllZdarzenie()
        {
            DataRepository dr = new DataRepository(new WypelnianieLosowymi());
            Assert.AreEqual(dr.GetAllZdarzenie().Count, 10);
        }

        [TestMethod]
        public void TestAddWypozyczenie()
        {
            DataRepository dr = new DataRepository(new WypelnianieLosowymi());
            int przed = dr.GetAllZdarzenie().Count;
            Katalog katalog1 = new Katalog(1, new Autor("Henryk", "Sienkiewicz"), "Potop", 1886);
            Wykaz wykaz1 = new Wykaz(20, "Oskar", "Tuszyński");
            OpisStanu opis1 = new OpisStanu(katalog1, 2, 35, DateTime.Now);
            dr.AddWypozyczenie(new Wypozyczenie(wykaz1, opis1, DateTime.Now));
            int po = dr.GetAllZdarzenie().Count;
            Assert.AreEqual(przed+1, po);
        }


        [TestMethod]
        public void TestAddZwrot()
        {
            DataRepository dr = new DataRepository(new WypelnianieLosowymi());
            int przed = dr.GetAllZdarzenie().Count;
            Katalog katalog1 = new Katalog(1, new Autor("Henryk", "Sienkiewicz"), "Potop", 1886);
            Wykaz wykaz1 = new Wykaz(20, "Oskar", "Tuszyński");
            OpisStanu opis1 = new OpisStanu(katalog1, 2, 35, DateTime.Now);
            dr.AddZwrot(new Zwrot(wykaz1, opis1, DateTime.Now));
            int po = dr.GetAllZdarzenie().Count;
            Assert.AreEqual(przed + 1, po);
        }



        [TestMethod]
        public void TestAddOpisStanu()
        {
            DataRepository dr = new DataRepository(new WypelnianieStalymi());
            Assert.AreEqual(dr.GetAllOpisStanu().Count, 10);
            Katalog katalog1 = new Katalog(11, new Autor("Henryk", "Sienkiewicz"), "Powodz", 1886);
            dr.AddOpisStanu(new OpisStanu(katalog1, 1, 20.0, new DateTime(2019, 10, 27)));
            Assert.AreEqual(dr.GetAllOpisStanu().Count, 11);
        }

        [TestMethod]
        public void TestGetOpisStanu()
        {
            DataRepository dr = new DataRepository(new WypelnianieStalymi());
            Katalog katalog1 = new Katalog(1, new Autor("Henryk", "Sienkiewicz"), "Potop", 1886);
            Assert.AreEqual(dr.GetOpisStanu(katalog1).Cena, 20.0);
        }

        [TestMethod]
        public void TestGetAllOpisStanu()
        {
            DataRepository dr = new DataRepository(new WypelnianieStalymi());
            Assert.AreEqual(dr.GetAllOpisStanu().Count, 10);
        }

        [TestMethod]
        public void TestUpdateOpisStanu()
        {
            DataRepository dr = new DataRepository(new WypelnianieStalymi());
            Katalog katalog1 = new Katalog(1, new Autor("Henryk", "Sienkiewicz"), "Potop", 1886);
            Assert.AreEqual(dr.GetOpisStanu(katalog1).Cena, 20.0);
            dr.UpdateOpisStanu(katalog1, 5, 30.0, new DateTime(2019, 10, 20));
            Assert.AreEqual(dr.GetOpisStanu(katalog1).Cena, 30.0);
        }

        [TestMethod]
        public void TestDeleteOpisStanu()
        {
            DataRepository dr = new DataRepository(new WypelnianieStalymi());
            Assert.AreEqual(dr.GetAllOpisStanu().Count, 10);
            Katalog katalog1 = new Katalog(1, new Autor("Henryk", "Sienkiewicz"), "Potop", 1886);
            dr.DeleteOpisStanu(katalog1);
            Assert.AreEqual(dr.GetAllOpisStanu().Count, 9);
        }
    }
}

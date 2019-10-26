using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestWykaz()
        {
            Wykaz wykaz = new Wykaz(1, "Gabriel", "Nowak");
            Assert.AreEqual(wykaz.id, 1);
            Assert.AreEqual(wykaz.imie, "Gabriel");
            Assert.AreEqual(wykaz.nazwisko, "Nowak");
        }

        [TestMethod]
        public void TestKatalog()
        {
            Autor autor = new Autor("Henryk", "Sienkiewicz");
            Katalog katalog = new Katalog(autor, "Krzyzacy", 2019);
            Assert.AreEqual(katalog.autor, autor);
            Assert.AreEqual(katalog.rokWydania, 2019);
        }

        [TestMethod]
        public void TestOpisStanu()
        {
            Autor autor = new Autor("Henryk", "Sienkiewicz");
            Katalog katalog = new Katalog(autor, "Krzyzacy", 2019);
            OpisStanu opis = new OpisStanu(katalog, 1, 29.99, new DateTime(2019, 10, 20));
            DateTime data = new DateTime(2019, 10, 20);
            Assert.AreEqual(opis.dataZakupu, data);
        }

        [TestMethod]
        public void TestZdarzenie()
        {
            Wykaz osoba = new Wykaz(1, "Norbert", "Gierczak");
            Autor autor = new Autor("Henryk", "Sienkiewicz");
            Katalog katalog = new Katalog(autor, "Krzyzacy", 2019);
            OpisStanu opis = new OpisStanu(katalog, 1, 29.99, new DateTime(2019, 10, 20));
            Zdarzenie zdarzenie = new Zdarzenie(osoba, opis, new DateTime(2019, 10, 20));
            Assert.IsNull(zdarzenie.dataZwrotu);
            Assert.AreEqual(zdarzenie.dataZwrotu, null);
            zdarzenie.dataZwrotu = new DateTime(2019, 10, 21);
            Assert.IsNotNull(zdarzenie.dataZwrotu);
            Assert.AreEqual(zdarzenie.dataZwrotu, new DateTime(2019, 10, 21));
        }
    }
}

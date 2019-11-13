using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestWykaz()
        {
            Wykaz wykaz = new Wykaz(1, "Gabriel", "Nowak");
            Assert.AreEqual(wykaz.Id, 1);
            Assert.AreEqual(wykaz.Imie, "Gabriel");
            Assert.AreEqual(wykaz.Nazwisko, "Nowak");
        }

        [TestMethod]
        public void TestKatalog()
        {
            Autor autor = new Autor("Henryk", "Sienkiewicz");
            Katalog katalog = new Katalog(1, autor, "Krzyzacy", 2019);
            Assert.AreEqual(katalog.Autor, autor);
            Assert.AreEqual(katalog.RokWydania, 2019);
        }

        [TestMethod]
        public void TestOpisStanu()
        {
            Autor autor = new Autor("Henryk", "Sienkiewicz");
            Katalog katalog = new Katalog(1, autor, "Krzyzacy", 2019);
            OpisStanu opis = new OpisStanu(katalog, 1, 29.99, new DateTime(2019, 10, 20));
            DateTime data = new DateTime(2019, 10, 20);
            Assert.AreEqual(opis.DataZakupu, data);
        }

        [TestMethod]
        public void TestZdarzenie()
        {
            Wykaz osoba = new Wykaz(1, "Norbert", "Gierczak");
            Autor autor = new Autor("Henryk", "Sienkiewicz");
            Katalog katalog = new Katalog(1, autor, "Krzyzacy", 2019);
            OpisStanu opis = new OpisStanu(katalog, 1, 29.99, new DateTime(2019, 10, 20));
            Wypozyczenie zdarzenie = new Wypozyczenie(osoba, opis, new DateTime(2019, 10, 20));
            Assert.AreEqual(zdarzenie.Data, new DateTime(2019, 10, 20));
            Zwrot zdarzenie2 = new Zwrot(osoba, opis, new DateTime(2019, 10, 30));
            Assert.AreEqual(zdarzenie2.Ksiazka.Cena, opis.Cena);
        }
    }
}

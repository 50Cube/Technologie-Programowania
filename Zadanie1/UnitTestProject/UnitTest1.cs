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
            OpisStanu opis = new OpisStanu();
        }
    }
}

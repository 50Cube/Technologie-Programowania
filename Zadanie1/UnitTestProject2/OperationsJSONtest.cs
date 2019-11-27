using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie2;

namespace Tests2
{
    [TestClass]
    public class OperationsJSONtest
    {
        [TestMethod]
        public void TestSerializationKlasaA()
        {
            Kolekcje kolekcje = new Kolekcje();
            Kolekcje kolekcje2 = new Kolekcje();
            GrafObiektow grafObiektow = new GrafObiektow();

            grafObiektow.Wypelnij(kolekcje);
            OperacjeJSON.Zapisz(kolekcje);
            kolekcje2 = OperacjeJSON.Wczytaj();

            Assert.AreEqual(kolekcje.ObiektA.Liczba, kolekcje2.ObiektA.Liczba);
            Assert.AreEqual(kolekcje.ObiektA.Napis, kolekcje2.ObiektA.Napis);
            Assert.AreEqual(kolekcje.ObiektA.Data, kolekcje2.ObiektA.Data);
            Assert.AreEqual(kolekcje.ObiektA.Obiekt.Liczba, kolekcje2.ObiektB.Liczba);
        }

        [TestMethod]
        public void TestSerializationKlasaB()
        {
            Kolekcje kolekcje = new Kolekcje();
            Kolekcje kolekcje2 = new Kolekcje();
            GrafObiektow grafObiektow = new GrafObiektow();

            grafObiektow.Wypelnij(kolekcje);
            OperacjeJSON.Zapisz(kolekcje);
            kolekcje2 = OperacjeJSON.Wczytaj();

            Assert.AreEqual(kolekcje.ObiektB.Liczba, kolekcje2.ObiektB.Liczba);
            Assert.AreEqual(kolekcje.ObiektB.Napis, kolekcje2.ObiektB.Napis);
            Assert.AreEqual(kolekcje.ObiektB.Data, kolekcje2.ObiektB.Data);
            Assert.AreEqual(kolekcje.ObiektB.Obiekt.Liczba, kolekcje2.ObiektC.Liczba);
        }

        [TestMethod]
        public void TestSerializationKlasaC()
        {
            Kolekcje kolekcje = new Kolekcje();
            Kolekcje kolekcje2 = new Kolekcje();
            GrafObiektow grafObiektow = new GrafObiektow();

            grafObiektow.Wypelnij(kolekcje);
            OperacjeJSON.Zapisz(kolekcje);
            kolekcje2 = OperacjeJSON.Wczytaj();

            Assert.AreEqual(kolekcje.ObiektC.Liczba, kolekcje2.ObiektC.Liczba);
            Assert.AreEqual(kolekcje.ObiektC.Napis, kolekcje2.ObiektC.Napis);
            Assert.AreEqual(kolekcje.ObiektC.Data, kolekcje2.ObiektC.Data);
            Assert.AreEqual(kolekcje.ObiektC.Obiekt.Liczba, kolekcje2.ObiektA.Liczba);
        }
    }
}

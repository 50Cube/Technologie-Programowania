using System;

using Zadanie1;

namespace Zadanie2
{
    public class GrafObiektow 
    {
        public void Wypelnij(Kolekcje kolekcje)
        {
            KlasaA obiektA1 = null;
            KlasaA obiektA2 = null;
            KlasaA obiektA3 = null;
            KlasaA obiektA4 = null;
            KlasaB obiektB1 = null;
            KlasaB obiektB2 = null;
            KlasaB obiektB3 = null;
            KlasaB obiektB4 = null;
            KlasaC obiektC1 = null;
            KlasaC obiektC2 = null;
            KlasaC obiektC3 = null;
            KlasaC obiektC4 = null;


            obiektA1 = new KlasaA(10.2f, "NapisA1", new DateTime(2019, 11, 25), obiektB1);
            obiektA2 = new KlasaA(10.4f, "NapisA2", new DateTime(2019, 11, 26), obiektB2);
            obiektA3 = new KlasaA(10.3f, "NapisA3", new DateTime(2019, 11, 27), obiektB3);
            obiektA4 = new KlasaA(10.5f, "NapisA4", new DateTime(2019, 11, 28), obiektB3);

            obiektB1 = new KlasaB(22.2f, "NapisB1", new DateTime(2019, 12, 06), obiektC1);
            obiektB2 = new KlasaB(33.3f, "NapisB2", new DateTime(2019, 12, 07), obiektC2);
            obiektB3 = new KlasaB(44.4f, "NapisB3", new DateTime(2019, 12, 08), obiektC3);
            obiektB4 = new KlasaB(55.5f, "NapisB3", new DateTime(2019, 12, 08), obiektC3);

            obiektC1 = new KlasaC(0.1f, "NapisC1", new DateTime(2019, 10, 10), obiektA1);
            obiektC2 = new KlasaC(0.2f, "NapisC2", new DateTime(2019, 10, 11), obiektA2);
            obiektC3 = new KlasaC(0.3f, "NapisC3", new DateTime(2019, 10, 12), obiektA3);
            obiektC4 = new KlasaC(0.4f, "NapisC4", new DateTime(2019, 10, 13), obiektA3);

            kolekcje.ElementyKlasyA.Add(obiektA1);
            kolekcje.ElementyKlasyA.Add(obiektA2);
            kolekcje.ElementyKlasyA.Add(obiektA3);
            kolekcje.ElementyKlasyA.Add(obiektA4);

            kolekcje.ElementyKlasyB.Add(obiektB1);
            kolekcje.ElementyKlasyB.Add(obiektB2);
            kolekcje.ElementyKlasyB.Add(obiektB3);
            kolekcje.ElementyKlasyB.Add(obiektB4);

            kolekcje.ElementyKlasyC.Add(obiektC1);
            kolekcje.ElementyKlasyC.Add(obiektC2);
            kolekcje.ElementyKlasyC.Add(obiektC3);
            kolekcje.ElementyKlasyC.Add(obiektC4);
        }

        public string Wyswietl(Kolekcje kolekcje)
        {
            string tmp = "";

            tmp += "\nKolekcja obiektów klasy A:\n";

            foreach (KlasaA a in kolekcje.ElementyKlasyA)
                tmp += a.ToString() + "\n";

            tmp += "\nKolekcja obiektów klasy B:\n";

            foreach (KlasaB b in kolekcje.ElementyKlasyB)
                tmp += b.ToString() + "\n";

            tmp += "\nKolekcja obiektów klasy C:\n";

            foreach (KlasaC c in kolekcje.ElementyKlasyC)
                tmp += c.ToString() + "\n";

            return tmp;
        }
    }
}

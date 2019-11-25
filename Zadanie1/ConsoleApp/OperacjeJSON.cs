using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Zadanie1;

namespace Zadanie2
{
    public class OperacjeJSON
    {
        public static void Zapisz(Kolekcje kolekcje)
        {
            string json = JsonConvert.SerializeObject(kolekcje.ElementyKlasyA, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            System.IO.File.WriteAllText("Kolekcje.json", json);
            
        }

        public static void Wczytaj(Kolekcje kolekcje)
        {
            if (System.IO.File.Exists("Kolekcje.json"))
            {
                String json = System.IO.File.ReadAllText("Kolekcje.json");
                kolekcje.ElementyKlasyA = JsonConvert.DeserializeObject<List<KlasaA>>(json, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            }
            else throw new Exception("Plik 'Kolekcje.json' nie istnieje");
        }
    }
}

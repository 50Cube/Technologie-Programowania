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
            JsonSerializerSettings jsonsettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.All, ReferenceLoopHandling = ReferenceLoopHandling.Serialize };
            string json = JsonConvert.SerializeObject(kolekcje.ElementyKlasyA, Formatting.Indented, jsonsettings); 
            System.IO.File.WriteAllText("KolekcjeA.json", json);
        }

        public static void Wczytaj(Kolekcje kolekcje)
        {
            JsonSerializerSettings jsonsettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.All, ReferenceLoopHandling = ReferenceLoopHandling.Serialize };
            if (System.IO.File.Exists("KolekcjeA.json"))
            {
                String json = System.IO.File.ReadAllText("KolekcjeA.json");
                kolekcje.ElementyKlasyA = JsonConvert.DeserializeObject<List<KlasaA>>(json, jsonsettings);
 
            }
            else throw new Exception("Plik 'Kolekcje.json' nie istnieje");
        }
    }
}

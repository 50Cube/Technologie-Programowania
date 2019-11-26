using Newtonsoft.Json;
using System;

namespace Zadanie2
{
    public class OperacjeJSON
    {
        
        public static void Zapisz(Kolekcje kolekcje)
        {
            JsonSerializerSettings jsonsettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects, ReferenceLoopHandling = ReferenceLoopHandling.Serialize };
            string json = JsonConvert.SerializeObject(kolekcje, Formatting.Indented, jsonsettings); 
            System.IO.File.WriteAllText("Kolekcje.json", json);
        }

        public static Kolekcje Wczytaj()
        {
            Kolekcje kolekcje;
            JsonSerializerSettings jsonsettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects, ReferenceLoopHandling = ReferenceLoopHandling.Serialize };
            if (System.IO.File.Exists("Kolekcje.json"))
            {
                String json = System.IO.File.ReadAllText("Kolekcje.json");
                return kolekcje = JsonConvert.DeserializeObject<Kolekcje>(json, jsonsettings);
 
            }
            else throw new Exception("Plik 'Kolekcje.json' nie istnieje");
        }
    }
}

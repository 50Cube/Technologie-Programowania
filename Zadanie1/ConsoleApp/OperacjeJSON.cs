using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Zadanie1;

namespace Zadanie2
{
    public class OperacjeJSON
    {
        public static void Zapisz(DataContext dane)
        {
            string jsonWykaz = JsonConvert.SerializeObject(dane.ElementyWykazu, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            System.IO.File.WriteAllText("Wykazy.json", jsonWykaz);

            string jsonKatalog = JsonConvert.SerializeObject(dane.Katalogi, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Serialize, PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            System.IO.File.WriteAllText("Katalogi.json", jsonKatalog);

            string jsonOpisStanu = JsonConvert.SerializeObject(dane.OpisyStanu, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            System.IO.File.WriteAllText("OpisyStanu.json", jsonOpisStanu);

            string jsonZdarzenie = JsonConvert.SerializeObject(dane.Zdarzenia, Formatting.Indented, new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                TypeNameHandling = TypeNameHandling.All
            });
            System.IO.File.WriteAllText("Zdarzenia.json", jsonZdarzenie);
        }

        public static void Wczytaj(DataContext dane)
        {
            if (System.IO.File.Exists("Wykazy.json"))
            {
                String json = System.IO.File.ReadAllText("Wykazy.json");
                dane.ElementyWykazu = JsonConvert.DeserializeObject<List<Wykaz>>(json, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            }
            else throw new Exception("Plik 'Wykazy.json' nie istnieje");

            if (System.IO.File.Exists("Katalogi.json"))
            {
                String json = System.IO.File.ReadAllText("Katalogi.json");
                dane.Katalogi = JsonConvert.DeserializeObject<Dictionary<int, Katalog>>(json, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            }
            else throw new Exception("Plik 'Katalogi.json' nie istnieje");

            if (System.IO.File.Exists("OpisyStanu.json"))
            {
                String json = System.IO.File.ReadAllText("OpisyStanu.json");
                dane.OpisyStanu = JsonConvert.DeserializeObject<List<OpisStanu>>(json, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            }
            else throw new Exception("Plik 'OpisyStanu.json' nie istnieje");

            if (System.IO.File.Exists("Zdarzenia.json"))
            {
                String json = System.IO.File.ReadAllText("Zdarzenia.json");
                dane.Zdarzenia = JsonConvert.DeserializeObject<ObservableCollection<Zdarzenie>>(json, new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    TypeNameHandling = TypeNameHandling.Auto
                });
            }
            else throw new Exception("Plik 'Zdarzenia.json' nie istnieje");

        }
    }
}

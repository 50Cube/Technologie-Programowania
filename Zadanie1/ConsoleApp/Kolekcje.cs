using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
namespace Zadanie2
{
    [JsonObject]
    public class Kolekcje
    {
        [JsonConstructor]
        public Kolekcje()
        {
            ElementyKlasyA = new List<KlasaA>();
            ElementyKlasyB = new List<KlasaB>();
            ElementyKlasyC = new List<KlasaC>();
            
        }
        [JsonProperty]
        public List<KlasaA> ElementyKlasyA { get; set; }
        [JsonProperty]
        public List<KlasaB> ElementyKlasyB { get; set; }
        [JsonProperty]
        public List<KlasaC> ElementyKlasyC { get; set; }
    }
}

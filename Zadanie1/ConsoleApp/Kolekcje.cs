using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
namespace Zadanie2
{
    [JsonObject]
    public class Kolekcje : ISerializable
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ElementyKlasyA", this.ElementyKlasyA);
            info.AddValue("ElementyKlasyB", this.ElementyKlasyB);
            info.AddValue("ElementyKlasyC", this.ElementyKlasyC);
        }
    }
}

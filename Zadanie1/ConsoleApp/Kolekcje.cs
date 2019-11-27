using System.Collections.Generic;
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
            Obiekty = new List<object>();
        }

        public Kolekcje(SerializationInfo info, StreamingContext context)
        {
            Obiekty = (List<object>)info.GetValue("Obiekty", typeof(List<object>));
        }

        [JsonProperty]
        public List<object> Obiekty { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Obiekty", this.Obiekty);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
namespace Zadanie2
{
    [Serializable]
    [JsonObject]
    public class Kolekcje : ISerializable
    {
        [JsonConstructor]
        public Kolekcje()
        {
            ObiektA = new KlasaA();
            ObiektB = new KlasaB();
            ObiektC = new KlasaC();
        }

        public Kolekcje(SerializationInfo info, StreamingContext context)
        {
            ObiektA = (KlasaA)info.GetValue("ObiektA", typeof(KlasaA));
            ObiektB = (KlasaB)info.GetValue("ObiektB", typeof(KlasaB));
            ObiektC = (KlasaC)info.GetValue("ObiektC", typeof(KlasaC));
        }

        [JsonProperty]
        public KlasaA ObiektA { get; set; }
        [JsonProperty]
        public KlasaB ObiektB { get; set; }
        [JsonProperty]
        public KlasaC ObiektC { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ObiektA", this.ObiektA);
            info.AddValue("ObiektB", this.ObiektB);
            info.AddValue("ObiektC", this.ObiektC);
        }

        public override string ToString()
        {
            return "Obiekt A: " + this.ObiektA.ToString() + "\nObiekt B: " + this.ObiektB.ToString() + "\nObiekt C: " + this.ObiektC.ToString();
        }
    }
}

using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Zadanie1
{
    [Serializable]
    public abstract class Zdarzenie : ISerializable
    {
        [JsonConstructor]
        protected Zdarzenie(DateTime data)
        {
            this.Data = data;
        }

        protected Zdarzenie(SerializationInfo info, StreamingContext context)
        {
            string data = (string)info.GetValue("Data", typeof(string));
            try
            {
                this.Data = DateTime.ParseExact(data, "dd/MM/yyyy HH:mm:ss", null);
            }
            catch (System.FormatException)
            {
                this.Data = DateTime.ParseExact(data, "MM/dd/yyyy HH:mm:ss", null);
            }
        }

        public DateTime Data { get; set; }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Data", this.Data, typeof(string));
        }

        public override string ToString()
        {
            return "";
        }
    }
}

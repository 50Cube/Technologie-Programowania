using System;
using System.Runtime.Serialization;
namespace Zadanie1
{
    [Serializable]
    public abstract class Zdarzenie : ISerializable
    {
        protected Zdarzenie(DateTime data)
        {
            this.Data = data;
        }

        public DateTime Data { get; set; }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Data", this.Data);
        }

        public override string ToString()
        {
            return "";
        }
    }
}

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

        protected Zdarzenie(SerializationInfo info, StreamingContext context)
        {
            this.Data = (DateTime)info.GetValue("Data", typeof(DateTime));
        }

        public DateTime Data { get; set; }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Rodzaj", this.GetType(), typeof(String));
            info.AddValue("Data", this.Data, typeof(DateTime));
        }

        public override string ToString()
        {
            return "";
        }
    }
}

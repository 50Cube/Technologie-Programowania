using System;
using System.Runtime.Serialization;

namespace Zadanie1
{
    [Serializable]
    public class Wykaz : ISerializable
    {
        public Wykaz(int id, string imie, string nazwisko)
        {
            this.Id = id;
            this.Imie = imie;
            this.Nazwisko = nazwisko;
        }
        public Wykaz(SerializationInfo info, StreamingContext context)
        {
            this.Id = (int)info.GetValue("Id", typeof(int));
            this.Imie = (string)info.GetValue("Imie", typeof(string));
            this.Nazwisko = (string)info.GetValue("Nazwisko", typeof(string));

        }
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", this.Id,typeof(int));
            info.AddValue("Imie", this.Imie,typeof(string));
            info.AddValue("Nazwisko", this.Nazwisko,typeof(string));
        }

        public override string ToString()
        {
            return "ID: " + this.Id + ", imie: " + this.Imie + ", nazwisko: " + this.Nazwisko;
        }
    }
}

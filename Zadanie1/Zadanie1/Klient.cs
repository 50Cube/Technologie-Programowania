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

        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", this.Id);
            info.AddValue("Imie", this.Imie);
            info.AddValue("Nazwisko", this.Nazwisko);
        }

        public override string ToString()
        {
            return "ID: " + this.Id + ", imie: " + this.Imie + ", nazwisko: " + this.Nazwisko;
        }
    }
}

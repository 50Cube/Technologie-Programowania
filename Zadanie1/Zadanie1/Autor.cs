using System.Runtime.Serialization;

namespace Zadanie1
{
    public class Autor
    {
        public Autor(string imie, string nazwisko)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
        }

        public Autor(SerializationInfo info, StreamingContext context)
        {
            this.Imie = (string)info.GetValue("Imie", typeof(string));
            this.Nazwisko = (string)info.GetValue("Nazwisko", typeof(string));

        }

        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Imie", this.Imie, typeof(string));
            info.AddValue("Nazwisko", this.Nazwisko, typeof(string));
        }

        public override string ToString() => "Imie: " + this.Imie + ", Nazwisko: " + this.Nazwisko;
    }
}

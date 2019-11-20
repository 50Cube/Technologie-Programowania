using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
namespace Zadanie1
{
    [Serializable]
    public class Katalog : ISerializable
    {
        [JsonConstructor]
        public Katalog(int id, Autor autor, string tytul, int rokWydania)
        {
            this.Id = id;
            this.Autor = autor;
            this.Tytul = tytul;
            this.RokWydania = rokWydania;
        }

        public Katalog(SerializationInfo info, StreamingContext context)
        {
            this.Id = (int)info.GetValue("Id", typeof(int));
            this.Autor = new Autor(info.GetString("Imie"), info.GetString("Nazwisko"));
            this.Tytul = (string)info.GetValue("Tytul", typeof(string));
            this.RokWydania = (int)info.GetValue("RokWydania", typeof(int));
        }
        public int Id { get; set; }
        public Autor Autor { get; set; }
        public string Tytul { get; set; }
        public int RokWydania { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", this.Id, typeof(int));
            info.AddValue("Imie", this.Autor.Imie, typeof(string));
            info.AddValue("Nazwisko", this.Autor.Nazwisko, typeof(string));
            info.AddValue("Tytul", this.Tytul,typeof(string));
            info.AddValue("RokWydania", this.RokWydania,typeof(int));
        }

        public override string ToString()
        {
            return "ID: " + this.Id + ", Autor: " + this.Autor.ToString() + ", tytul: " + this.Tytul + ", rok wydania: " + this.RokWydania;
        }
    }
}

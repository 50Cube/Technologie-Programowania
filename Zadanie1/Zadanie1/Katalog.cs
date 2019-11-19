using System;
using System.Runtime.Serialization;

namespace Zadanie1
{
    [Serializable]
    public class Katalog : ISerializable
    {
        public Katalog(int id, Autor autor, string tytul, int rokWydania)
        {
            this.Id = id;
            this.Autor = autor;
            this.Tytul = tytul;
            this.RokWydania = rokWydania;
        }

        public int Id { get; set; }
        public Autor Autor { get; set; }
        public string Tytul { get; set; }
        public int RokWydania { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", this.Id);
            info.AddValue("Autor", this.Autor);
            info.AddValue("Tytul", this.Tytul);
            info.AddValue("RokWydania", this.RokWydania);
        }

        public override string ToString()
        {
            return "ID: " + this.Id + ", Autor: " + this.Autor.ToString() + ", tytul: " + this.Tytul + ", rok wydania: " + this.RokWydania;
        }
    }
}

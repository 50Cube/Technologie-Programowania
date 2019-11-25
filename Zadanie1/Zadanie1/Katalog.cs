namespace Zadanie1
{
    public class Katalog
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
        
        public override string ToString()
        {
            return "ID: " + this.Id + ", Autor: " + this.Autor.ToString() + ", tytul: " + this.Tytul + ", rok wydania: " + this.RokWydania;
        }
    }
}

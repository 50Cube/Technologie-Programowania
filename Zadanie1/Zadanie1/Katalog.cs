namespace Zadanie1
{
    public class Katalog
    {
        public Katalog(Autor autor, string tytul, int rokWydania)
        {
            this.autor = autor;
            this.tytul = tytul;
            this.rokWydania = rokWydania;
        }

        public Autor autor { get; set; }
        public string tytul { get; set; }
        public int rokWydania { get; set; }
    }
}

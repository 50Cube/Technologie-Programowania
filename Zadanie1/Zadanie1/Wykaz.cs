namespace Zadanie1
{
    public class Wykaz
    {
        public Wykaz(int id, string imie, string nazwisko)
        {
            this.id = id;
            this.imie = imie;
            this.nazwisko = nazwisko;
        }

        public int id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }

    }
}

namespace Zadanie1
{
    public class Wykaz
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

        public override string ToString()
        {
            return "ID: " + this.Id + ", imie: " + this.Imie + ", nazwisko: " + this.Nazwisko;
        }
    }
}

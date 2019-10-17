namespace Zadanie1
{
    public class Wykaz
    {
        private int id;
        private string imie;
        private string nazwisko;

        public Wykaz(int id, string imie, string nazwisko)
        {
            this.id = id;
            this.imie = imie;
            this.nazwisko = nazwisko;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Imie
        {
            get { return imie; }
            set { imie = value; }
        }

        public string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; }
        }

    }
}

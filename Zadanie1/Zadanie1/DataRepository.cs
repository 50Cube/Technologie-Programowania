using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class DataRepository : IDataRepository
    {
        private DataContext dataContext = new DataContext();

        public DataRepository(IWypelnianie wypelnianie)
        {
            wypelnianie.Wypelnij(dataContext);
        }

        public void AddWykaz(Wykaz wykaz)
        {
            foreach (Wykaz w in dataContext.ElementyWykazu)
                if (w.Id == wykaz.Id)
                    throw new Exception("Klient juz istnieje");

            dataContext.ElementyWykazu.Add(wykaz);
        }

        public Wykaz GetWykaz(int id)
        {
            foreach (Wykaz w in dataContext.ElementyWykazu)
                if (w.Id == id)
                    return w;

            throw new Exception("Nie ma takiego klienta");
        }

        public List<Wykaz> GetAllWykaz()
        {
            return dataContext.ElementyWykazu;
        }

        public bool UpdateWykaz(int id, string imie, string nazwisko)
        {
            foreach (Wykaz w in dataContext.ElementyWykazu)
            {
                if (w.Id == id)
                {
                    w.Imie = imie;
                    w.Nazwisko = nazwisko;
                    return true;
                }
            }
            throw new Exception("Nie ma takiego klienta");
        }

        public bool DeleteWykaz(Wykaz wykaz)
        {
            foreach (Wykaz w in dataContext.ElementyWykazu.ToList())
                if (w.Id == wykaz.Id)
                {
                    dataContext.ElementyWykazu.Remove(wykaz);
                    return true;
                }

            throw new Exception("Nie ma takiego klienta");
        }


        public void AddKatalog(Katalog katalog)
        {
            if (dataContext.Katalogi.ContainsKey(katalog.Id))
                throw new Exception("Taka ksiazka juz istnieje");

            dataContext.Katalogi.Add(katalog.Id, katalog);
        }

        public Katalog GetKatalog(int id)
        {
            if (dataContext.Katalogi.ContainsKey(id))
                return dataContext.Katalogi[id];
            else throw new Exception("Nie ma takiej ksiazki");
        }

        public Dictionary<int,Katalog> GetAllKatalog()
        {
            return dataContext.Katalogi;
        }

        public void UpdateKatalog(int id, Autor autor, string tytul, int rok)
        {
            if (dataContext.Katalogi.ContainsKey(id))
            {
                dataContext.Katalogi[id].Autor = autor;
                dataContext.Katalogi[id].Tytul = tytul;
                dataContext.Katalogi[id].RokWydania = rok;
            }
            else throw new Exception("Nie ma takiej ksiazki");
        }

        public void DeleteKatalog(int id)
        {
            if (dataContext.Katalogi.ContainsKey(id))
                dataContext.Katalogi.Remove(id);
            else throw new Exception("Nie ma takiej ksiazki");
        }


        // CRUD dla Zdarzenie
        public ObservableCollection<Zdarzenie> GetAllZdarzenie()
        {
            return dataContext.Zdarzenia;
        }

        public void AddWypozyczenie(Wypozyczenie w)
        {
            dataContext.Zdarzenia.Add(w);
        }

        public void AddZwrot(Zwrot z)
        {
            dataContext.Zdarzenia.Add(z);
        }

        public void AddOpisStanu(OpisStanu opis)
        {
            foreach (OpisStanu os in dataContext.OpisyStanu)
                if (os.Katalog == opis.Katalog)
                    throw new Exception("Wpis juz istnieje");

            dataContext.OpisyStanu.Add(opis);
        }

        public OpisStanu GetOpisStanu(Katalog katalog)
        {
            foreach (OpisStanu os in dataContext.OpisyStanu)
                if (os.Katalog.Id == katalog.Id)
                    return os;

            throw new Exception("Nie ma takiego wpisu");
        }

        public List<OpisStanu> GetAllOpisStanu()
        {
            return dataContext.OpisyStanu;
        }

        public bool UpdateOpisStanu(Katalog katalog, int ilosc, double cena, DateTime data)
        {
            foreach (OpisStanu os in dataContext.OpisyStanu)
            {
                if (os.Katalog.Id == katalog.Id)
                {
                    os.Ilosc = ilosc;
                    os.Cena = cena;
                    os.DataZakupu = data;
                    return true;
                }
            }
            throw new Exception("Nie ma takiego wpisu");
        }

        public bool DeleteOpisStanu(Katalog katalog)
        {
            foreach (OpisStanu os in dataContext.OpisyStanu.ToList())
                if (os.Katalog.Id == katalog.Id)
                {
                    dataContext.OpisyStanu.Remove(os);
                    return true;
                }

            throw new Exception("Nie ma takiego wpisu");
        }
    }
}

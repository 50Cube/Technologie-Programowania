using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class DataService
    {
        private readonly IDataRepository dataRepository;
        public DataService(IDataRepository dR)
        {
            dataRepository = dR;
        }

        public void AddWykaz(Wykaz k)
        {
            dataRepository.AddWykaz(k);
        }

        public void DeleteWykaz(Wykaz k)
        {
            dataRepository.DeleteWykaz(k);
        }

        public Wykaz GetWykaz(int i)
        {
            return dataRepository.GetWykaz(i);
        }

        public List<Wykaz> GetWykazList()
        {
            return dataRepository.GetAllWykaz();
        }

        public void AddKatalog(Katalog k)
        {
            dataRepository.AddKatalog(k);
        }

        public void DeleteKatalog(int id)
        {
            dataRepository.DeleteKatalog(id);
        }

        public Katalog GetKatalog(int id)
        {
           return dataRepository.GetKatalog(id);
        }

        public Dictionary<int,Katalog> GetAllKatalog()
        {
           return dataRepository.GetAllKatalog();
        }

        public void UpdateKatalog(int id, Autor autor, string tytul, int rok)
        {
            dataRepository.UpdateKatalog(id, autor, tytul, rok);
        }

        public List<OpisStanu> GetAllOpisStanu()
        {
           return dataRepository.GetAllOpisStanu();
        }

        public OpisStanu GetOpisStanu(Katalog k)
        {
            return dataRepository.GetOpisStanu(k);
        }

        public void UpdateOpisStanu(Katalog katalog, int ilosc, double cena, DateTime data)
        {
            dataRepository.UpdateOpisStanu(katalog, ilosc, cena, data);
        }

        public void Wypozycz(Wykaz klient, Katalog ksiazka)
        {
            OpisStanu stan = dataRepository.GetOpisStanu(ksiazka);
            if (stan.Ilosc > 0)
            {
                dataRepository.UpdateOpisStanu(ksiazka, stan.Ilosc - 1, stan.Cena, stan.DataZakupu);
                Wypozyczenie w = new Wypozyczenie(klient, stan, DateTime.Now);
                dataRepository.AddWypozyczenie(w);
            }
            else throw new ArgumentException("Brak ksiazki do wypozyczenia");
        }

        public void Zwroc(Wykaz klient, Katalog ksiazka)
        {
            OpisStanu stan = dataRepository.GetOpisStanu(ksiazka);
            dataRepository.UpdateOpisStanu(ksiazka, stan.Ilosc + 1, stan.Cena, stan.DataZakupu);
            Zwrot z = new Zwrot(klient, stan, DateTime.Now);
            dataRepository.AddZwrot(z);
        }

    }
}

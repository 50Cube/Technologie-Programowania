using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Zadanie1
{
    public interface IDataRepository
    {
        void AddKatalog(Katalog katalog);
        void AddOpisStanu(OpisStanu opis);
        void AddWykaz(Wykaz wykaz);
        void DeleteKatalog(int id);
        bool DeleteOpisStanu(Katalog katalog);
        bool DeleteWykaz(Wykaz wykaz);
        Dictionary<int, Katalog> GetAllKatalog();
        List<OpisStanu> GetAllOpisStanu();
        List<Wykaz> GetAllWykaz();
        Katalog GetKatalog(int id);
        OpisStanu GetOpisStanu(Katalog katalog);
        ObservableCollection<Zdarzenie> GetAllZdarzenie();
        Zdarzenie GetZdarzenie(int i);
        Wykaz GetWykaz(int id);
        List<string> GetZdarzeniaLog();
        void UpdateKatalog(int id, Autor autor, string tytul, int rok);
        bool UpdateOpisStanu(Katalog katalog, int ilosc, double cena, DateTime data);
        bool UpdateWykaz(int id, string imie, string nazwisko);
        void AddZwrot(Zwrot z);
        void AddWypozyczenie(Wypozyczenie w);
    }
}
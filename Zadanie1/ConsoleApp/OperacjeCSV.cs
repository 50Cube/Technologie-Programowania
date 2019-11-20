﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Zadanie1;

namespace Zadanie2
{
    public class OperacjeCSV 
    {
        private static readonly string Delimiter = ",";
        private static StringBuilder stringBuilder = new StringBuilder();

        public static void Zapisz(DataContext data)
        {
            foreach (Wykaz w in data.ElementyWykazu)
                stringBuilder.AppendLine(string.Join(Delimiter,w.Id, w.Imie, w.Nazwisko));
            System.IO.File.WriteAllText("Wykazy.csv", stringBuilder.ToString());

            stringBuilder = new StringBuilder();
            foreach (Katalog k in data.Katalogi.Values)
                stringBuilder.AppendLine(string.Join(Delimiter, k.Id, k.Autor.Imie, k.Autor.Nazwisko, k.Tytul, k.RokWydania));
            System.IO.File.WriteAllText("Katalogi.csv", stringBuilder.ToString());

            stringBuilder = new StringBuilder();
            foreach (OpisStanu o in data.OpisyStanu)
                stringBuilder.AppendLine(string.Join(Delimiter, o.Katalog.Id, o.Ilosc, o.Cena, o.DataZakupu));
            System.IO.File.WriteAllText("OpisyStanu.csv", stringBuilder.ToString());

            //stringBuilder = new StringBuilder();
            //foreach (Zdarzenie z in data.Zdarzenia)
            //    stringBuilder.AppendLine(string.Join(Delimiter, ));
            //System.IO.File.WriteAllText("Zdarzenia.csv", stringBuilder.ToString());
        }

        public static void Wczytaj(DataContext data)
        {
            
        }
    }
}

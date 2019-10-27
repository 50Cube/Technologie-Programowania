using System;

namespace Zadanie1
{
    public class WypelnianieLosowymi : IWypelnianie
    {
        public void Wypelnij(DataContext dataContext)
        {
            Random random = new Random();
            for (int i = 1; i < 11; i++)
            {
                dataContext.ElementyWykazu.Add(new Wykaz(i, Convert.ToString(random.Next(1,10000)), Convert.ToString(random.Next(1, 10000))));
            }

            for (int i = 1; i < 11; i++)
            {
                dataContext.Katalogi.Add(i, new Katalog(i, new Autor(Convert.ToString(random.Next(1, 10000)), Convert.ToString(random.Next(1, 10000))), Convert.ToString(random.Next(1, 10000)), random.Next(1, 10000)));
            }

            for (int i= 0; i < dataContext.Katalogi.Count; i++)
            {
                dataContext.OpisyStanu.Add(new OpisStanu(dataContext.Katalogi[i+1], random.Next(1, 20), random.NextDouble() * 50, new DateTime(2019, 10, random.Next(1, 31))));
            }

            for (int i = 0; i < 10; i++)
            {
                dataContext.Zdarzenia.Add(new Wypozyczenie(dataContext.ElementyWykazu[2], dataContext.OpisyStanu[i], new DateTime(2019, 11, random.Next(1, 30))));
            }
        }
    }
}

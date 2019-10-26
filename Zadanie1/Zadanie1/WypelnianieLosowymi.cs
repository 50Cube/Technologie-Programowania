using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class WypelnianieLosowymi : IWypelnianie
    {
        public void wypelnij(DataContext dataContext)
        {
            Random random = new Random();
            for (int i = 1; i < 11; i++)
            {
                dataContext.elementyWykazu.Add(new Wykaz(i, Convert.ToString(random.Next(1,10000)), Convert.ToString(random.Next(1, 10000))));
            }

            for (int i = 1; i < 11; i++)
            {
                dataContext.katalogi.Add(i, new Katalog(new Autor(Convert.ToString(random.Next(1, 10000)), Convert.ToString(random.Next(1, 10000))), Convert.ToString(random.Next(1, 10000)), random.Next(1, 10000)));
            }

            for (int i= 0; i < dataContext.katalogi.Count; i++)
            {
                dataContext.opisyStanu.Add(new OpisStanu(dataContext.katalogi[i], random.Next(1, 20), random.NextDouble() * 50, new DateTime(2019, 10, random.Next(1, 31))));
            }

            for (int i = 0; i < 11; i++)
            {
                dataContext.zdarzenia.Add(new Zdarzenie(dataContext.elementyWykazu[2], dataContext.opisyStanu[i], new DateTime(2019, 11, random.Next(1, 30))));
            }
        }
    }
}

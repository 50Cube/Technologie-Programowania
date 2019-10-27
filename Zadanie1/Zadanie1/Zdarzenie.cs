using System;

namespace Zadanie1
{
    public abstract class Zdarzenie
    {
        public DateTime Data;

        protected Zdarzenie(DateTime data)
        {
            this.Data = data;
        }
    }
}

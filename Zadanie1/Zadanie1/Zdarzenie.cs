using System;

namespace Zadanie1
{
    public abstract class Zdarzenie
    {
        protected Zdarzenie(DateTime data)
        {
            this.Data = data;
        }

        public DateTime Data { get; set; }
        public override string ToString()
        {
            return "";
        }
    }
}

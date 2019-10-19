using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class DataContext
    {
        public DataContext()
        {
            elementyWykazu = new List<Wykaz>();
        }

        public List<Wykaz> elementyWykazu { get; }
        
    }
}

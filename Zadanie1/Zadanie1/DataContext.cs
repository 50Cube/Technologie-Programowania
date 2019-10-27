using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Zadanie1
{
    public class DataContext
    {
        public DataContext()
        {
            ElementyWykazu = new List<Wykaz>();
            Katalogi = new Dictionary<int, Katalog>();
            Zdarzenia = new ObservableCollection<Zdarzenie>();
            OpisyStanu = new List<OpisStanu>();
        }

        public List<Wykaz> ElementyWykazu { get; }
        public Dictionary<int,Katalog> Katalogi { get; }
        public ObservableCollection<Zdarzenie> Zdarzenia { get; }
        public List<OpisStanu> OpisyStanu { get; }
    }
}

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
            ZdarzeniaLog = new List<string>();
        }

        public List<Wykaz> ElementyWykazu { get; set; }
        public Dictionary<int,Katalog> Katalogi { get; set; }
        public ObservableCollection<Zdarzenie> Zdarzenia { get; set; }
        public List<OpisStanu> OpisyStanu { get; set; }
        public List<string> ZdarzeniaLog { get; }

    }
}

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Zadanie1
{
    public class DataContext
    {
        public DataContext()
        {
            elementyWykazu = new List<Wykaz>();
            katalogi = new Dictionary<int, Katalog>();
            zdarzenia = new ObservableCollection<Zdarzenie>();
            opisyStanu = new List<OpisStanu>();
        }

        public List<Wykaz> elementyWykazu { get; }
        public Dictionary<int,Katalog> katalogi { get; }
        public ObservableCollection<Zdarzenie> zdarzenia { get; }
        public List<OpisStanu> opisyStanu { get; }
    }
}

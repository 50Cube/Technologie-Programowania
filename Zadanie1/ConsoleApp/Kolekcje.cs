using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Zadanie2
{
    public class Kolekcje
    {
        public Kolekcje()
        {
            ElementyKlasyA = new List<KlasaA>();
            ElementyKlasyB = new ObservableCollection<KlasaB>();
            ElementyKlasyC = new List<KlasaC>();
            
        }

        public List<KlasaA> ElementyKlasyA { get; set; }
        public ObservableCollection<KlasaB> ElementyKlasyB { get; set; }
        public List<KlasaC> ElementyKlasyC { get; set; }
    }
}

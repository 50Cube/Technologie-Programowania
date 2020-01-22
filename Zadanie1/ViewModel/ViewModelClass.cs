using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ViewModel
{
    public class ViewModelClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private DataRepository DataRepository { get; set; }
        private Product product;
        private ObservableCollection<Product> products;

        public ViewModelClass()
        {
            DataRepository = new DataRepository();
            Products = new ObservableCollection<Product>(DataRepository.GetAll().ToList());
            Product = new Product();
            ShowAddWindow = new MyCommand(DisplayAddWindow);
        }

        public ICommand ShowAddWindow
        {
            get; private set;
        }

        public System.Lazy<IWindow> AddWindow { get; set; }

        private void DisplayAddWindow()
        {
            IWindow window = AddWindow.Value;
            window.Show();
        }

        public Product Product
        {
            get => product;

            set
            {
                product = value;
                RaisePropertyChanged("Product");
            }
        }

        public ObservableCollection<Product> Products
        {
            get => products;

            set
            {
                products = value;
                RaisePropertyChanged("Products");
            }
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

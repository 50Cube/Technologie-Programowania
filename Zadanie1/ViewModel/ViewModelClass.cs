using Model;
using System.Collections.Generic;
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
            DisplayAddWindow = new MyCommand(ShowAddWindow);
            ShowInfo = new RelayCommand(ShowInfoWindow);
        }

        public ICommand ShowInfo
        {
            get; private set;
        }

        public System.Lazy<IWindow> ChildWindow { get; set; }

        private void ShowInfoWindow()
        {
            IWindow _child = ChildWindow.Value;
            _child.Show();
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

        public MyCommand DisplayAddWindow { get; set; }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ShowAddWindow()
        {

        }
    }
}

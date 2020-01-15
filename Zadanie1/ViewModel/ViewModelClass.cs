using Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace ViewModel
{
    public class ViewModelClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Product Product;
        private List<Product> Products;

        public DataRepository DataRepository { get; set; }

        public ICommand AddProductCommand { get; set; }
        public ICommand UpdateProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }

        public ViewModelClass()
        {

        }
    }
}

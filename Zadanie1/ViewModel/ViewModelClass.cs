using Model;
using System;
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
        private Product newProduct;
        private ObservableCollection<Product> products;

        public ViewModelClass()
        {
            DataRepository = new DataRepository();
            Products = new ObservableCollection<Product>(DataRepository.GetAll().ToList());
            Product = new Product();
            ShowAddWindow = new MyCommand(DisplayAddWindow);
            DeleteCommand = new MyCommand(DeleteProduct);
            AddProductCommand = new MyCommand(AddNewProduct);
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

        public ICommand ShowAddWindow { get; private set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AddProductCommand { get; set; }
        
        public System.Lazy<IWindow> AddWindow { get; set; }

        private void DisplayAddWindow()
        {
            IWindow window = AddWindow.Value;
            window.Show();
        }

        private void DeleteProduct()
        {
            DataRepository.Delete(this.Product.ProductID);
        }

        private void AddNewProduct()
        {
            newProduct = new Product
            {
                Name = this._Name,
                ProductNumber = _ProductNumber,
                MakeFlag = _MakeFlag,
                FinishedGoodsFlag = _FinishedGoodsFlag,
                Color = _Color,
                SafetyStockLevel = _SafetyStockLevel,
                ReorderPoint = _ReorderPoint,
                StandardCost = _StandardCost,
                ListPrice = _ListPrice,
                Size = _Size,
                SizeUnitMeasureCode = _SizeUnitMeasureCode,
                WeightUnitMeasureCode = _WeightUnitMeasureCode,
                Weight = _Weight,
                DaysToManufacture = _DaysToManufacture,
                ProductLine = _ProductLine,
                Class = _Class,
                Style = _Style,
                ProductSubcategoryID = _ProductSubcategoryID,
                ProductModelID = _ProductModelID,
                SellStartDate = DateTime.Now,
                SellEndDate = _SellEndDate,
                rowguid = Guid.NewGuid(),
                ModifiedDate = DateTime.Now
            };
            DataRepository.Add(newProduct);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region properties
        private string _Name;
        private string _ProductNumber;
        private bool _MakeFlag;
        private bool _FinishedGoodsFlag;
        private string _Color;
        private short _SafetyStockLevel = 1;
        private short _ReorderPoint = 1;
        private decimal _StandardCost;
        private decimal _ListPrice;
        private string _Size;
        private string _SizeUnitMeasureCode;
        private string _WeightUnitMeasureCode;
        private decimal _Weight = 1;
        private int _DaysToManufacture;
        private string _ProductLine;
        private string _Class;
        private string _Style;
        private int? _ProductSubcategoryID;
        private int? _ProductModelID;
        private DateTime? _SellEndDate;
        private Guid _Rowguid = new Guid();

        public string Name
        {
            get => _Name;
            set { _Name = value; RaisePropertyChanged("Name"); }
        }

        public string ProductNumber
        {
            get => _ProductNumber;
            set { _ProductNumber = value; RaisePropertyChanged("ProductNumber"); }
        }

        public bool MakeFlag
        {
            get => _MakeFlag;
            set { _MakeFlag = value; RaisePropertyChanged("MakeFlag"); }
        }

        public bool FinishedGoodsFlag
        {
            get => _FinishedGoodsFlag;
            set { _FinishedGoodsFlag = value; RaisePropertyChanged("FinishedGoodsFlag"); }
        }

        public string Color
        {
            get => _Color;
            set { _Color = value; RaisePropertyChanged("Color"); }
        }

        public short SafetyStockLevel
        {
            get => _SafetyStockLevel;
            set { _SafetyStockLevel = value; RaisePropertyChanged("SafetyStockLevel"); }
        }

        public short ReorderPoint
        {
            get => _ReorderPoint;
            set { _ReorderPoint = value; RaisePropertyChanged("ReorderPoint"); }
        }

        public decimal StandardCost
        {
            get => _StandardCost;
            set { _StandardCost = value; RaisePropertyChanged("StandardCost"); }
        }

        public decimal ListPrice
        {
            get => _ListPrice;
            set { _ListPrice = value; RaisePropertyChanged("ListPrice"); }
        }

        public string Size
        {
            get => _Size;
            set { _Size = value; RaisePropertyChanged("Size"); }
        }

        public string SizeUnitMeasureCode
        {
            get => _SizeUnitMeasureCode;
            set { _SizeUnitMeasureCode = value; RaisePropertyChanged("SizeUnitMeasureCode"); }
        }

        public string WeightUnitMeasureCode
        {
            get => _WeightUnitMeasureCode;
            set { _WeightUnitMeasureCode = value; RaisePropertyChanged("WeightUnitMeasureCode"); }
        }

        public decimal Weight
        {
            get => _Weight;
            set { _Weight = value; RaisePropertyChanged("Weight"); }
        }

        public int DaysToManufacture
        {
            get => _DaysToManufacture;
            set { _DaysToManufacture = value; RaisePropertyChanged("DaysToManufacture"); }
        }

        public string ProductLine
        {
            get => _ProductLine;
            set { _ProductLine = value; RaisePropertyChanged("ProductLine"); }
        }

        public string Class
        {
            get => _Class;
            set { _Class = value; RaisePropertyChanged("Class"); }
        }

        public string Style
        {
            get => _Style;
            set { _Style = value; RaisePropertyChanged("Style"); }
        }

        public int? ProductSubcategoryID
        {
            get => _ProductSubcategoryID;
            set { _ProductSubcategoryID = value; RaisePropertyChanged("ProductSubcategoryID"); }
        }

        public int? ProductModelID
        {
            get => _ProductModelID;
            set { _ProductModelID = value; RaisePropertyChanged("ProductModelID"); }
        }

        public DateTime? SellEndDate
        {
            get => _SellEndDate;
            set { _SellEndDate = value; RaisePropertyChanged("SellEndDate"); }
        }
        #endregion
    }
}

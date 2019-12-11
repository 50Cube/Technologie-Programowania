using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3sql
{
    class MyProductRepository
    {
        List<MyProduct> myProducts { get; set; }

        public MyProductRepository()
        {
            myProducts = new List<MyProduct>();
            this.fill();
        }

        private void fill()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                var productVendorPair = (from product in db.Products
                                     join vendor in db.ProductVendors on product.ProductID equals vendor.ProductID
                                     select new { product, vendorName = vendor.Vendor.Name }).ToList();

                foreach (var x in productVendorPair)
                {
                    myProducts.Add(new MyProduct(x.product, x.vendorName));
                }
            }
        }
    }
}

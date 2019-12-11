using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3sql
{
    public class MyProductRepository
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
                    decimal tax = x.product.StandardCost * 0.1m;
                    myProducts.Add(new MyProduct(x.product, tax, x.vendorName));
                }
            }
        }

        public List<MyProduct> GetProductsByVendorName(string vendorName)
        {
            List<MyProduct> returnedList = (from product in myProducts
                                          where product.vendorName.Equals(vendorName)
                                          select product).ToList();
            return returnedList;
        }

        public  List<MyProduct> GetProductsByName(string namePart)
        {
            List<MyProduct> returnedList = (from product in myProducts
                                where product.Name.Contains(namePart)
                                select product).ToList();
                return returnedList;
        }

        public  List<MyProduct> GetProductsWithNRecentReviews(int howManyReviews)
        {
            List<MyProduct> returnedList = (from product in myProducts
                    where product.ProductReviews.Count.Equals(howManyReviews)
                    select product).ToList();
            return returnedList;
        }
    }
}

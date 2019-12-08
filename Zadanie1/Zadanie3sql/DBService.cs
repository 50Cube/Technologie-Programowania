using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3sql
{
    public class DBService
    {
        public static List<Product> GetProductsByName(string namePart)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<Product> returnedList;
                Table<Product> productTable = db.GetTable<Product>();
                returnedList = (from product in productTable
                                where product.Name.Contains(namePart)
                                select product).ToList();
                return returnedList;
            }
        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<Product> returnedList = (from product in db.Products
                                              join productVendor in db.ProductVendors on product.ProductID equals productVendor.ProductID
                                              join vendor in db.Vendors on productVendor.BusinessEntityID equals vendor.BusinessEntityID
                                              where vendor.Name.Equals(vendorName)
                                              select product).ToList();
                return returnedList;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3sql
{
    public static class ExtensionMethods
    {
        public static List<Product> GetProductsWithoutCategoryDeclarative()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<Product> returnedList = (from product in db.Products
                                              where product.ProductSubcategoryID.Equals(null)
                                              select product).ToList();
                return returnedList;
            }
        }

        public static List<Product> GetProductsWithoutCategoryImperative(this List<Product> list)
        {
            List<Product> returnedList = new List<Product>();

            foreach (Product product in list)
                if (product.ProductSubcategoryID.Equals(null))
                    returnedList.Add(product);

            return returnedList;
        }

        public static List<Product> GetProductsSiteDeclarative(int size, int number)
        {
            if (size < 0 || number < 1) throw new Exception("Wrong argument");
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<Product> returnedList = (from product in db.Products
                                              select product).Skip(size * (number-1)).Take(size).ToList();

                return returnedList;
            }
        }

        public static List<Product> GetProductsSiteImperative(this List<Product> list, int size, int number)
        {
            if (size < 0 || number < 1) throw new Exception("Wrong argument");

            return list.Skip(size * (number - 1)).Take(size).ToList();
        }

        public static string GetProductsAndVendors(this List<Product> products, List<ProductVendor> vendors)
        {
            StringBuilder result = new StringBuilder();
            var returnedValue = (from product in products
                                           join vendor in vendors on product.ProductID equals vendor.ProductID
                                           select new { productName = product.Name, vendorName = vendor.Vendor.Name }).ToList();

            foreach (var x in returnedValue)
            {
                result.AppendLine(x.productName + "-" + x.vendorName);
            }

            return result.ToString();
        }
    }
}

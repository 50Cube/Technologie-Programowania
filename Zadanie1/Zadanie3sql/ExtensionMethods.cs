using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zadanie3sql
{
    public static class ExtensionMethods
    {
        public static List<Product> GetProductsWithoutCategoryDeclarative(this List<Product> products)
        {
                return (from product in products
                        where product.ProductSubcategoryID.Equals(null)
                        select product).ToList();
        }

        public static List<Product> GetProductsWithoutCategoryImperative(this List<Product> products)
        {
            return products.Where(product => product.ProductSubcategoryID.Equals(null)).ToList();
        }

        public static List<Product> GetProductsSiteDeclarative(this List<Product> products, int size, int number)
        {
            if (size < 0 || number < 1) throw new Exception("Wrong argument");

                return (from product in products
                        select product).Skip(size * (number-1)).Take(size).ToList();
        }

        public static List<Product> GetProductsSiteImperative(this List<Product> products, int size, int number)
        {
            if (size < 0 || number < 1) throw new Exception("Wrong argument");

            return products.Skip(size * (number - 1)).Take(size).ToList();
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

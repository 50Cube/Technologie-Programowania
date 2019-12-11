using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace Zadanie3sql
{
    public class DBService
    {
        public static List<Product> GetProductsByName(string namePart)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<Product> returnedList = (from product in db.Products
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

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<string> returnedList = (from product in db.Products
                                              join productVendor in db.ProductVendors on product.ProductID equals productVendor.ProductID
                                              join vendor in db.Vendors on productVendor.BusinessEntityID equals vendor.BusinessEntityID
                                              where vendor.Name.Equals(vendorName)
                                              select product.Name).ToList();
                return returnedList;
            }
        }

        public static string GetProductVendorByProductName(string productName)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<String> returnedValue = (from product in db.Products
                                             join productVendor in db.ProductVendors on product.ProductID equals productVendor.ProductID
                                             join vendor in db.Vendors on productVendor.BusinessEntityID equals vendor.BusinessEntityID
                                             where product.Name.Equals(productName)
                                             select vendor.Name).ToList();
                return returnedValue[0];
            }
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<Product> returnedList = (from productReview in db.ProductReviews
                                              join product in db.Products on productReview.ProductID equals product.ProductID
                                              orderby productReview.ReviewDate
                                              select product).Take(howManyReviews).ToList();
                return returnedList;
            }
        }

        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<Product> returnedList = (from product in db.Products
                                              join productReview in db.ProductReviews on product.ProductID equals productReview.ProductID
                                              orderby productReview.ReviewDate
                                              select product).Take(howManyProducts).ToList();
                return returnedList;
            }
        }

        public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<Product> returnedList = (from product in db.Products
                                              join productSubcategory in db.ProductSubcategories on product.ProductSubcategoryID equals productSubcategory.ProductSubcategoryID
                                              join productCategory in db.ProductCategories on productSubcategory.ProductCategoryID equals productCategory.ProductCategoryID
                                              where productCategory.Name.Equals(categoryName)
                                              select product).Take(n).ToList();
                return returnedList;
            }
        }

        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                decimal returnedValue = (from product in db.Products
                                              join productSubcategory in db.ProductSubcategories on product.ProductSubcategoryID equals productSubcategory.ProductSubcategoryID
                                              join productCategory in db.ProductCategories on productSubcategory.ProductCategoryID equals productCategory.ProductCategoryID
                                              where productCategory.Equals(category)
                                              select product.StandardCost).ToList().Sum();

                return (int) returnedValue;
            }
        }
    }
}

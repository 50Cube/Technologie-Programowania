using System.Reflection;

namespace Zadanie3sql
{
    public class MyProduct : Product
    {
        public decimal tax { get; set; }
        public string vendorName { get; set; }
        public MyProduct(Product product, decimal tax, string vendorName)   
        {
            this.vendorName = vendorName;
            this.tax = tax;
            foreach (PropertyInfo property in product.GetType().GetProperties())
            {
                if (property.CanWrite)
                    property.SetValue(this, property.GetValue(product));
            }
        }
    }
}

using System.Reflection;

namespace Zadanie3sql
{
    public class MyProduct : Product
    {
        public string vendorName { get; set; }
        public MyProduct(Product product, string vendorName)
        {
            this.vendorName = vendorName;
            foreach (PropertyInfo property in product.GetType().GetProperties())
            {
                if (property.CanWrite)
                    property.SetValue(this, property.GetValue(product));
            }
        }
    }
}

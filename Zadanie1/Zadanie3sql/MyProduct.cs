using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3sql
{
    public class MyProduct : Product
    {
        string vendorName { get; set; }
        public MyProduct(Product product, string vendorName)
        {
            this.vendorName = vendorName;
            foreach (var property in product.GetType().GetProperties())
            {
                if (property.CanWrite)
                    property.SetValue(this, property.GetValue(product));
            }
        }
    }
}

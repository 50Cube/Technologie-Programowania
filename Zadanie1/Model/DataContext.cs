using System.Data.Linq;
using System.Linq;
using System.Reflection;

namespace Model
{
    public class DataContext : IDataContext<Product>
    {
        private DataClassesDataContext Database;

        public DataContext()
        {
            this.Database = new DataClassesDataContext();
        }

        public void Add(Product element)
        {
            Database.Products.InsertOnSubmit(element);
            Database.SubmitChanges(ConflictMode.ContinueOnConflict); // konflikty powinny być gromadzone i zwracane na końcu procesu
        }

        public void Delete(Product element)
        {
            Database.Products.DeleteOnSubmit(element);
            Database.SubmitChanges(ConflictMode.ContinueOnConflict);
        }

        public Product Get(int ID)
        {
            return Database.Products.Where(p => p.ProductID == ID).FirstOrDefault();
        }

        public IQueryable<Product> GetAll()
        {
            return Database.Products;
        }

        public void Update(Product element)
        {
            Product tmp = Database.Products.Where(p => p.ProductID == element.ProductID).FirstOrDefault();
            
            foreach(PropertyInfo property in tmp.GetType().GetProperties())
            {
                property.SetValue(tmp, property.GetValue(element));
            }

            Database.SubmitChanges(ConflictMode.ContinueOnConflict);
        }
    }
}

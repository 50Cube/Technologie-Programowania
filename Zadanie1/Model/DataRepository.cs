using Data;
using System.Linq;

namespace Model
{
    public class DataRepository : IDataRepository<Product>
    {
        private IDataContext<Product> DataContext;

        public DataRepository()
        {
            this.DataContext = new DataContext();
        }

        public void Add(Product element)
        {
            DataContext.Add(element);
        }

        public Product Get(int ID)
        {
            return DataContext.Get(ID);
        }

        public void Delete(int ID)
        {
            DataContext.Delete(this.Get(ID));
        }

        public IQueryable<Product> GetAll()
        {
            return DataContext.GetAll();
        }

        public void Update(Product element)
        {
            DataContext.Update(element);
        }
    }
}

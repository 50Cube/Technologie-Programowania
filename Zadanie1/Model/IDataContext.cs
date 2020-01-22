using System.Linq;

namespace Model
{
    interface IDataContext<T>
    {
        IQueryable<T> GetAll();
        T Get(int ID);
        void Add(T element);
        void Delete(T element);
        void Update(T element);
    }
}

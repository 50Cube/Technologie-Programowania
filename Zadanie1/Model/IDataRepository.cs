using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    interface IDataRepository<T>
    {
        IQueryable<T> GetAll();
        T Get(int ID);
        void Add(T element);
        void Delete(int ID);
        void Update(T element);
    }
}

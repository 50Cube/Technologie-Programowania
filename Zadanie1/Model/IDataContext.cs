using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

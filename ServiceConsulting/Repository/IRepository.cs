using System.Collections.Generic;
using DataBase.Data;

namespace ServiceConsulting.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T item);
        void Remove(long id);
        void Update(T item);
        T FindByID(long id);
        IEnumerable<T> FindAll();
    }
}

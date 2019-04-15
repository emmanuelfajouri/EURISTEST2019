using System;
using System.Collections.Generic;

namespace EURIS.Data.Contracts
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Add(T entity);
        void Update(T entity);
        //void Update(List<T> entity);
        void Remove(T entity);
        //void UpdateDisconnected(T manifiesto);
    }
}

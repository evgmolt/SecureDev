using System;
using System.Collections.Generic;

namespace DebetCards.Data
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T item);
        Task Update(T item);
        Task Delete(T item);
    }
}

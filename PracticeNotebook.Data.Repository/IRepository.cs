using System.Collections.Generic;

namespace PracticeNotebook.Data.Repository
{
    public interface IRepository<T> where T:class
    {
        int Insert(T obj);
        int Update(T obj);
        int Delete(int id);
        T GetById(int id);
        // faster than list
        IEnumerable<T> GetAll();
    }
}
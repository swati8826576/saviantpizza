using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SaviantPizza.Repository.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);

        IEnumerable<T> Search(Expression<Func<T, Boolean>> predicate);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id); 
        void Save();
    }
}


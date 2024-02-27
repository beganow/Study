using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }
        void Remove(T entity);
        void Add(T entity);
        void Update(T entity);
    }
}

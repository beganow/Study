
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityState = System.Data.Entity.EntityState;

namespace lab9
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MyDbContext _dbContext;
        private IDbSet<T> _dbSet => _dbContext.Set<T>();
        public IQueryable<T> Entities => _dbSet;
        public Repository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
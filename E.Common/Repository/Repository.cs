using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace E.Common.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext _context;
        private DbSet<T> _dbSet;
        public Repository(DbContext context) {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null)
        {
            if (filter==null) { 
                return _dbSet.AsQueryable(); 
            }
            return _dbSet.Where(filter).AsQueryable();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}

using E.Common.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace E.Common.Repository
{
    public interface IRepository<T> where T:BaseEntity,new()
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> Get(Expression<Func<T, bool>> filter = null);
    }
}

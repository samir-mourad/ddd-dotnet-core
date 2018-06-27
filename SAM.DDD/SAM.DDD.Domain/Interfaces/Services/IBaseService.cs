using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SAM.DDD.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null
                         , Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null
                         , string includeProperties = null
                         , int start = 0
                         , int length = 100);

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}

using SAM.DDD.Domain.Interfaces.Repositories;
using SAM.DDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SAM.DDD.Application
{
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> baseRepository;

        public BaseService(IBaseRepository<T> _baseRepository) => baseRepository = _baseRepository;

        public virtual void Add(T entity) => baseRepository.Add(entity);

        public virtual void Delete(T entity) => baseRepository.Delete(entity);

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null
                                , Func<IQueryable<T>
                                , IOrderedQueryable<T>> orderBy = null
                                , string includeProperties = null
                                , int start = 0
                                , int length = 100) => baseRepository.Get(filter, orderBy, includeProperties, start, length);

        public T GetById(int id) => baseRepository.GetById(id);

        public virtual void Update(T entity) => baseRepository.Update(entity);
    }
}

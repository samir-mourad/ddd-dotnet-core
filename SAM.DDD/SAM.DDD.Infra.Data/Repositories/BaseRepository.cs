
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SAM.DDD.Domain.Interfaces.Repositories;
using SAM.DDD.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace SAM.DDD.Infra.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly EFContext context;
        private DbSet<T> dbSet;

        public BaseRepository(EFContext _context)
        {
            context = _context;
            dbSet = context.Set<T>();
        }

        public void Add(T entity) => context.Add(entity);

        public void Delete(T entity)
        {
            var ativoProperty = entity.GetType().GetProperty("Ativo");
            
            if(ativoProperty == null)
                throw new Exception();
            else
            {
                ativoProperty.SetValue(entity, false);
                dbSet.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }


        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null, int start = 0, int length = 100)
        {
            var query = dbSet.AsQueryable();

            if(!string.IsNullOrWhiteSpace(includeProperties))
                foreach (var i in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    dbSet.Include(i);

            if (filter != null)
               query = query.Where(filter);

            if (orderBy != null)
                orderBy(query);

            return query.Skip(start)
                        .Take(length)
                        .AsNoTracking()
                        .ToArray();
        }

        public T GetById(int id) => context.Find(typeof(T), id) as T;
    }
}

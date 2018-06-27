using SAM.DDD.Domain.Interfaces.Context;
using System;

namespace SAM.DDD.Infra.Data.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFContext context;
        private bool disposed = false;

        public UnitOfWork(EFContext _context) => context = _context;

        public void Commit() => context.SaveChanges(); 

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing && context != null)
                context.Dispose();

            disposed = true;
        }
    }
}

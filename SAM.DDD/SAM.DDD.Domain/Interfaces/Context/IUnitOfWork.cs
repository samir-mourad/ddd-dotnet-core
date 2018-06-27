using System;
using System.Collections.Generic;
using System.Text;

namespace SAM.DDD.Domain.Interfaces.Context
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}

using SAM.DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAM.DDD.Domain.Interfaces.Repositories
{
    public interface IHierarquiaColaboradorRepository : IBaseRepository<HierarquiaColaborador>
    {
        IEnumerable<HierarquiaColaborador> GetAll();
        IEnumerable<HierarquiaColaborador> GetByFuncional(int funcionalColaborador);
        bool HasChild(int numeroFuncional);
    }
}

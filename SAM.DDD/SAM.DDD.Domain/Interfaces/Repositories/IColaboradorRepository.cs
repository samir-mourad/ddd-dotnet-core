
using SAM.DDD.Domain.Entities;
using System.Collections.Generic;

namespace SAM.DDD.Domain.Interfaces.Repositories
{
    public interface IColaboradorRepository : IBaseRepository<Colaborador>
    {
        Colaborador GetByEmailOrId(string email, int? id = null);
    }
}

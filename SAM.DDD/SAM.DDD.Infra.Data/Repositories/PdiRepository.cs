using SAM.DDD.Domain.Entities;
using SAM.DDD.Domain.Interfaces.Repositories;
using SAM.DDD.Infra.Data.Context;

namespace SAM.DDD.Infra.Data.Repositories
{
    public class PdiRepository : BaseRepository<Pdi>, IPdiRepository
    {
        public PdiRepository(EFContext _context) : base(_context)
        {
        }
    }
}

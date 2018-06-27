using SAM.DDD.Domain.Entities;
using SAM.DDD.Domain.Interfaces.Repositories;
using SAM.DDD.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAM.DDD.Infra.Data.Repositories
{
    public class EixosRepository: BaseRepository<Eixo>, IEixosRepository
    {
        public EixosRepository(EFContext _context) : base(_context)
        {
        }
    }
}

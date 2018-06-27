using System.Collections.Generic;
using System.Linq;
using SAM.DDD.Domain.Entities;
using SAM.DDD.Domain.Interfaces.Repositories;
using SAM.DDD.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace SAM.DDD.Infra.Data.Repositories
{
    public class ColaboradorRepository : BaseRepository<Colaborador>, IColaboradorRepository
    {
        public ColaboradorRepository(EFContext _context) : base(_context)
        {
        }

        public Colaborador GetByEmailOrId(string email, int? id = null)
        {
            return context.Colaborador.Where(i => i.IdUsuarioSGI == id 
                                               || i.Email.Equals(email))
                                      .FirstOrDefault();
        }
    }
}

using SAM.DDD.Domain.Entities;
using SAM.DDD.Domain.Interfaces.Repositories;
using SAM.DDD.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAM.DDD.Infra.Data.Repositories
{
    public class CompetenciasColaboradorRepository : BaseRepository<CompetenciaColaborador>, ICompetenciasColaboradorRepository
    {
        public CompetenciasColaboradorRepository(EFContext _context) : base(_context)
        {
        }
    }
}

using SAM.DDD.Domain.Entities;
using System.Collections.Generic;

namespace SAM.DDD.Domain.Interfaces.Services
{
    public interface IHierarquiaColaboradorService : IBaseService<HierarquiaColaborador>
    {
        IEnumerable<HierarquiaColaborador> Listar(int funcionalColaborador, bool ehAdministrador);
    }
}

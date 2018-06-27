using SAM.DDD.Domain.Entities;

namespace SAM.DDD.Domain.Interfaces.Services
{
    public interface IColaboradorService : IBaseService<Colaborador>
    {
        Colaborador UpdateIdSgi(string email, int? id = null);
    }
}

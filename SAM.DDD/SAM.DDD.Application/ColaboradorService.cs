using SAM.DDD.Domain.Entities;
using SAM.DDD.Domain.Interfaces.Context;
using SAM.DDD.Domain.Interfaces.Repositories;
using SAM.DDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAM.DDD.Application
{
    public class ColaboradorService : BaseService<Colaborador>, IColaboradorService
    {
        private readonly IColaboradorRepository colaboradorRepository;
        private readonly IHierarquiaColaboradorRepository hierarquiaRepository;
        private readonly IUnitOfWork unitOfWork;

        public ColaboradorService(IColaboradorRepository _colaboradorRepository, IHierarquiaColaboradorRepository _hierarquiaRepository, IUnitOfWork _unitOfWork) : base(_colaboradorRepository) {
            colaboradorRepository = _colaboradorRepository;
            hierarquiaRepository = _hierarquiaRepository;
            unitOfWork = _unitOfWork;
        }


        public Colaborador UpdateIdSgi(string email, int? id = null)
        {
            using (unitOfWork)
            {
                var colaborador = colaboradorRepository.GetByEmailOrId(email, id);

                if (colaborador != null)
                {
                    colaborador.IdUsuarioSGI = (int)id;
                    base.Update(colaborador);

                    var hasChild = hierarquiaRepository.HasChild(colaborador.NumeroFuncional);

                    colaborador.TemSubordinados = hasChild;

                    unitOfWork.Commit();
                }

                return colaborador;
            }

        }

        public override void Add(Colaborador entity)
        {
            using (unitOfWork)
            {
                base.Add(entity);
                unitOfWork.Commit();
            }
        }

        public override void Delete(Colaborador entity)
        {
            using (unitOfWork)
            {
                base.Delete(entity);
                unitOfWork.Commit();
            }
        }
    }
}

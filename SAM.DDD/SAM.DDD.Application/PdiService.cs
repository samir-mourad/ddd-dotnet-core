using SAM.DDD.Domain.Entities;
using SAM.DDD.Domain.Interfaces.Context;
using SAM.DDD.Domain.Interfaces.Repositories;
using SAM.DDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAM.DDD.Application
{
    public class PdiService: BaseService<Pdi>,IPdiService
    {
        private readonly IPdiRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public  PdiService(IPdiRepository _repository, IUnitOfWork _unitOfWork) : base(_repository)
        {
            repository = _repository;
            unitOfWork = _unitOfWork;
        }

        public override void Add(Pdi entity)
        {
            using (unitOfWork)
            {
                base.Add(entity);
                unitOfWork.Commit();
            }
        }
    }
}

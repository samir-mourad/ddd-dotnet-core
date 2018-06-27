using AutoMapper;
using SAM.DDD.Domain.Entities;
using SAM.DDD.Application.ViewModels;

namespace SAM.DDD.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Colaborador, ColaboradorViewModel>();
            CreateMap<Pdi, PdiViewModel>();
            CreateMap<Eixo, EixoViewModel>();
            CreateMap<Competencia, CompetenciaViewModel>();
            CreateMap<CompetenciaColaborador, CompetenciaColaboradorViewModel>();
            CreateMap<HierarquiaColaborador, HierarquiaColaboradorViewModel>();
        }
    }
}

using AutoMapper;
using SAM.DDD.Domain.Entities;
using SAM.DDD.Application.ViewModels;

namespace SAM.DDD.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ColaboradorViewModel, Colaborador>();
            CreateMap<PdiViewModel, Pdi>();
            CreateMap<EixoViewModel, Eixo>();
            CreateMap<CompetenciaViewModel, Competencia>();
            CreateMap<CompetenciaColaboradorViewModel, CompetenciaColaborador>();
            CreateMap<HierarquiaColaboradorViewModel, HierarquiaColaborador>();
        }
    }
}
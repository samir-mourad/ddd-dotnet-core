using AutoMapper;
using SAM.DDD.Application;
using SAM.DDD.Domain.Interfaces.Context;
using SAM.DDD.Domain.Interfaces.Repositories;
using SAM.DDD.Domain.Interfaces.Services;
using SAM.DDD.Infra.Data.Context;
using SAM.DDD.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SAM.DDD.Infra.CrossCutting.IoC
{
    public class Ioc
    {
        public static IServiceCollection RegisterDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<EFContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            RegisterRepositories(services);
            RegisterServices(services);

            return services;
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IColaboradorService, ColaboradorService>();
            services.AddScoped<IPdiService, PdiService>();

        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            services.AddScoped<IEixosRepository, EixosRepository>();
            services.AddScoped<ICompetenciasColaboradorRepository, CompetenciasColaboradorRepository>();
            services.AddScoped<ICompetenciasRepository, CompetenciasRepository>();
            services.AddScoped<IPdiRepository, PdiRepository>();
        }
    }
}

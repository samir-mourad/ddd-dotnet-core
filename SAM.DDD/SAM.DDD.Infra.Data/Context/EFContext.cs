using SAM.DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SAM.DDD.Infra.Data.Context
{
    public class EFContext : DbContext
    {
        private IConfiguration config;

        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<Competencia> Competencia { get; set; }
        public DbSet<CompetenciaColaborador> CompetenciaColaborador { get; set; }
        public DbSet<ConfiguracaoPeriodoPdi> ConfiguracaoPeriodoPdi { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<HierarquiaColaborador> HierarquiaColaborador { get; set; }
        public DbSet<OpcaoAcaoDesenvolvimento> OpcaoAcaoDesenvolvimento { get; set; }
        public DbSet<Pdi> Pdi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.LoadMappings();
            modelBuilder.SetStringToVarchar();
            modelBuilder.SetDateTime();
            modelBuilder.DisableDeleteCascade();

            base.OnModelCreating(modelBuilder);
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (config == null)
                config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                   .AddJsonFile("appsettings.json")
                                                   .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"))
                          .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            base.OnConfiguring(optionsBuilder);
        }

    }

    public static class ContextExtensions
    {

        public static void DisableDeleteCascade(this ModelBuilder m)
        {
            var foreignKeys = m.Model
                               .GetEntityTypes()
                               .SelectMany(t => t.GetForeignKeys())
                               .Where(fk => !fk.IsOwnership
                                         && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var f in foreignKeys)
                f.DeleteBehavior = DeleteBehavior.Restrict;
        }

        public static void LoadMappings(this ModelBuilder m)
        {
            var typesToMap = Assembly.GetExecutingAssembly()
                                     .GetTypes()
                                     .Where(x => !string.IsNullOrWhiteSpace(x.Namespace)
                                              && x.Namespace.EndsWith("Mappings")
                                              && !x.IsSealed)
                                     .ToArray();

            foreach (var t in typesToMap)
            {
                dynamic mappingClass = Activator.CreateInstance(t);
                m.ApplyConfiguration(mappingClass);
            }
        }

        public static void SetStringToVarchar(this ModelBuilder m)
        {
            var props = m.Model.GetEntityTypes()
                               .SelectMany(t => t.GetProperties())
                               .Where(t => t.ClrType == typeof(string))
                               .Select(t => t);

            foreach (var prop in props)
            {
                var p = m.Entity(prop.DeclaringEntityType.ClrType).Property(prop.Name);
                var type = prop.GetMaxLength() > 0 ? $"varchar({prop.GetMaxLength()})" : "text";

                p.HasColumnType(type);
            }
        }

        public static void SetDateTime(this ModelBuilder m)
        {
            var props = m.Model.GetEntityTypes()
                               .SelectMany(t => t.GetProperties())
                               .Where(t => t.ClrType == typeof(DateTime) 
                                        || t.ClrType == typeof(DateTime?))
                               .Select(t => t);

            foreach (var prop in props)
            {
                var p = m.Entity(prop.DeclaringEntityType.ClrType).Property(prop.Name);
                p.HasColumnType("datetime");
            }
        }
    }
}

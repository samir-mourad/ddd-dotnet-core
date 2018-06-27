using SAM.DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SAM.DDD.Infra.Data.Mappings
{
    public class HierarquiaColaboradorMapping : IEntityTypeConfiguration<HierarquiaColaborador>
    {
        public void Configure(EntityTypeBuilder<HierarquiaColaborador> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.AnoReferencia);

            builder.HasOne(p => p.Colaborador)
                   .WithMany(p => p.Hierarquia)
                   .HasForeignKey(p => p.FuncionalColaborador);

            builder.HasOne(p => p.Superior)
                   .WithMany()
                   .HasForeignKey(p => p.FuncionalSuperior)
                   .IsRequired(false);

            builder.HasOne(p => p.Departamento)
                   .WithMany(p => p.HierarquiaColaborador)
                   .HasForeignKey(p => p.IdDepartamento);

            builder.HasOne(p => p.Cargo)
                   .WithMany()
                   .HasForeignKey(p => p.IdCargo);

            builder.Property(p => p.AnoReferencia)
                   .IsRequired()
                   .HasColumnType("smallint");
                   
        }
    }
}

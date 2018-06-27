using SAM.DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SAM.DDD.Infra.Data.Mappings
{
    public class DepartamentoMapping : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.DepartamentoSuperior)
                   .WithMany(p => p.Departamentos)
                   .HasForeignKey(p => p.IdDepartamentoSuperior)
                   .IsRequired(false);

            builder.HasMany(p => p.Departamentos)
                   .WithOne(p => p.DepartamentoSuperior);

            builder.HasMany(p => p.PdiMovimentacoesLateral)
                   .WithOne(p => p.Departamento);

            builder.HasMany(p => p.HierarquiaColaborador)
                   .WithOne(p => p.Departamento);

            builder.HasOne(p => p.ColaboradorResponsavel)
                   .WithMany(p => p.ResponsavelDepartamentos)
                   .HasForeignKey(p => p.FuncionalColaboradorResponsavel);

            builder.HasIndex(p => p.AnoReferencia);

            builder.HasIndex(p => new { p.AnoReferencia, p.CodigoInternoArea })
                   .IsUnique();

            builder.Property(p => p.AnoReferencia)
                   .IsRequired()
                   .HasColumnType("smallint");

            builder.Property(p => p.CodigoInternoArea)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(p => p.Descricao)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.DescricaoAbreviada)
                   .IsRequired(false)
                   .HasMaxLength(10);
        }
    }
}

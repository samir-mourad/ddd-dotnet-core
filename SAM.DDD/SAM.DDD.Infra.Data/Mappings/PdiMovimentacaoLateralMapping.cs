using SAM.DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SAM.DDD.Infra.Data.Mappings
{
    public class PdiMovimentacaoLateralMapping : IEntityTypeConfiguration<PdiMovimentacaoLateral>
    {
        public void Configure(EntityTypeBuilder<PdiMovimentacaoLateral> builder)
        {
            builder.HasKey(p => new { p.IdPdi, p.IdDepartamento } );

            builder.HasOne(p => p.Pdi)
                   .WithMany(p => p.PdisMovimentacoesLateral)
                   .HasForeignKey(p => p.IdPdi);

            builder.HasOne(p => p.Departamento)
                   .WithMany(p => p.PdiMovimentacoesLateral)
                   .HasForeignKey(p => p.IdDepartamento);
        }
    }
}

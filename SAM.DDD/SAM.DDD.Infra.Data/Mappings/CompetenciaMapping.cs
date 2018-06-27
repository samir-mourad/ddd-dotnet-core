using SAM.DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SAM.DDD.Infra.Data.Mappings
{
    public class CompetenciaMapping : IEntityTypeConfiguration<Competencia>
    {
        public void Configure(EntityTypeBuilder<Competencia> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.Detalhe)
                   .IsRequired();

            builder.Property(p => p.Ativo)
                   .IsRequired()
                   .HasDefaultValue(true);

            builder.Property(p => p.DataExclusao)
                   .IsRequired(false);

            builder.Property(p => p.IdUsuarioExclusao)
                   .IsRequired(false);
        }
    }
}

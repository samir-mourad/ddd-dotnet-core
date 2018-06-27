using SAM.DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SAM.DDD.Infra.Data.Mappings
{
    public class OpcaoAcaoDesenvolvimentoMapping : IEntityTypeConfiguration<OpcaoAcaoDesenvolvimento>
    {
        public void Configure(EntityTypeBuilder<OpcaoAcaoDesenvolvimento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.PdisOpcoesAcoesDesenvolvimento)
                   .WithOne(p => p.OpcaoAcaoDesenvolvimento);

            builder.Property(p => p.Descricao)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.Detalhe)
                   .IsRequired();

            builder.Property(p => p.Ativo)
                   .IsRequired()
                   .HasDefaultValue(true);

            builder.Property(p => p.PossuiObservacao)
                   .IsRequired();

            builder.Property(p => p.DataExclusao)
                   .IsRequired(false);

            builder.Property(p => p.IdUsuarioExclusao)
                   .IsRequired(false);
        }
    }
}

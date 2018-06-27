using SAM.DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SAM.DDD.Infra.Data.Mappings
{
    public class PdiOpcaoAcaoDesenvolvimentoMapping : IEntityTypeConfiguration<PdiOpcaoAcaoDesenvolvimento>
    {
        public void Configure(EntityTypeBuilder<PdiOpcaoAcaoDesenvolvimento> builder)
        {
            builder.HasKey(p => new { p.IdOpcaoAcaoDesenvolvimento, p.IdPdi });

            builder.HasOne(p => p.Pdi)
                   .WithMany(p => p.PdisOpcoesAcoesDesenvolvimento)
                   .HasForeignKey(p => p.IdPdi);

            builder.HasOne(p => p.OpcaoAcaoDesenvolvimento)
                   .WithMany(p => p.PdisOpcoesAcoesDesenvolvimento)
                   .HasForeignKey(p => p.IdOpcaoAcaoDesenvolvimento);

            builder.Property(p => p.Observacao)
                   .IsRequired(false);
        }
    }
}

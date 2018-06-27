using SAM.DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SAM.DDD.Infra.Data.Mappings
{
    public class PdiMapping : IEntityTypeConfiguration<Pdi>
    {
        public void Configure(EntityTypeBuilder<Pdi> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Colaborador)
                   .WithMany(p => p.Pdis)
                   .HasForeignKey(p => p.FuncionalColaborador);

            builder.HasMany(p => p.PdisOpcoesAcoesDesenvolvimento)
                   .WithOne(p => p.Pdi);

            builder.HasMany(p => p.PdisMovimentacoesLateral)
                   .WithOne(p => p.Pdi);

            builder.HasOne(p => p.Status)
                   .WithMany()
                   .HasForeignKey(p => p.IdStatus);

            builder.HasIndex(p => p.AnoReferencia);

            builder.HasIndex(p => new { p.AnoReferencia, p.FuncionalColaborador })
                   .IsUnique();

            builder.Property(p => p.AnoReferencia)
                   .HasColumnType("smallint")
                   .IsRequired();

            builder.Property(p => p.DescricaoPontoForte)
                   .IsRequired();

            builder.Property(p => p.DescricaoPontoDesenvolver)
                   .IsRequired();

            builder.Property(p => p.Expectativa)
                   .IsRequired();

            builder.Property(p => p.MovimentacaoLateral)
                   .IsRequired();

            builder.Property(p => p.DescricaoMovimentacaoLateralOutros)
                   .IsRequired(false);

            builder.Property(p => p.MovimentacaoNacional)
                   .IsRequired();

            builder.Property(p => p.IdUsuarioCriacao)
                   .IsRequired();

            builder.Property(p => p.Ativo)
                   .IsRequired()
                   .HasDefaultValue(true);

            builder.Property(p => p.NumeroVersao)
                   .IsRequired()
                   .HasColumnType("tinyint");

            builder.Property(p => p.DataCriacao)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}

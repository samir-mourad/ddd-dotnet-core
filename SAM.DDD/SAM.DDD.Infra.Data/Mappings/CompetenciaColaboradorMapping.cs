using SAM.DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace SAM.DDD.Infra.Data.Mappings
{
    public class CompetenciaColaboradorMapping : IEntityTypeConfiguration<CompetenciaColaborador>
    {
        public void Configure(EntityTypeBuilder<CompetenciaColaborador> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Colaborador)
                   .WithMany(p => p.Competencias)
                   .HasForeignKey(p => p.FuncionalColaborador);

            builder.HasOne(p => p.Competencia)
                   .WithMany()
                   .HasForeignKey(p => p.IdCompetencia);

            builder.HasIndex(p => p.AnoReferencia);

            builder.HasIndex(p => new { p.AnoReferencia, p.FuncionalColaborador })
                   .IsUnique();

            builder.Property(p => p.AnoReferencia)
                   .HasColumnType("smallint")
                   .IsRequired();

            builder.Property(p => p.ExpectativaColaborador)
                   .IsRequired();

            builder.Property(p => p.NotaAvaliacaoColaborador)
                   .IsRequired(false);

            builder.Property(p => p.NotaAvaliacaoGestor)
                   .IsRequired(false);

            builder.Property(p => p.NotaPrioridadeColaborador)
                   .IsRequired(false);

            builder.Property(p => p.NotaPrioridadeGestor)
                   .IsRequired(false);

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

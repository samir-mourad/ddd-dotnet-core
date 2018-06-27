using SAM.DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAM.DDD.Infra.Data.Mappings
{
    public class EixoMapping : IEntityTypeConfiguration<Eixo>
    {
        public void Configure(EntityTypeBuilder<Eixo> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Colaborador)
                   .WithMany(p => p.Eixos)
                   .HasForeignKey(p => p.FuncionalColaborador);

            builder.HasIndex(p => p.AnoReferencia);

            builder.HasIndex(p => new { p.AnoReferencia, p.FuncionalColaborador })
                   .IsUnique();

            builder.Property(p => p.AnoReferencia)
                   .HasColumnType("smallint")
                   .IsRequired();

            builder.Property(p => p.NotaEixoX)
                   .IsRequired(false);

            builder.Property(p => p.NotaEixoY)
                   .IsRequired(false);
        }
    }
}

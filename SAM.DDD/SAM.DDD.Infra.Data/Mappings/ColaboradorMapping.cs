using SAM.DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SAM.DDD.Infra.Data.Mappings
{
    public class ColaboradorMapping : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.HasKey(p => p.NumeroFuncional);

            builder.HasMany(p => p.Pdis)
                   .WithOne(p => p.Colaborador);

            builder.HasMany(p => p.ResponsavelDepartamentos)
                   .WithOne(p => p.ColaboradorResponsavel);

            builder.HasMany(p => p.Competencias)
                   .WithOne(p => p.Colaborador);

            builder.HasMany(p => p.Eixos)
                   .WithOne(p => p.Colaborador);

            builder.HasMany(p => p.Hierarquia)
                   .WithOne(p => p.Colaborador);

            builder.HasIndex(p => p.NumeroFuncional)
                   .IsUnique();

            builder.HasIndex(p => p.Email)
                   .IsUnique();

            builder.Property(p => p.IdUsuario)
                   .IsRequired();

            builder.Property(p => p.NomeCompleto)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Ativo)
                   .IsRequired()
                   .HasDefaultValue(true);

            builder.Ignore(p => p.TemSubordinados);
        }
    }
}

using SAM.DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SAM.DDD.Infra.Data.Mappings
{
    public class CargoMapping : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.DescricaoNivel)
                   .IsRequired()
                   .HasMaxLength(20);
        }
    }
}

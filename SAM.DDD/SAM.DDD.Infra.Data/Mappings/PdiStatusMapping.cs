using SAM.DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SAM.DDD.Infra.Data.Mappings
{
    public class PdiStatusMapping : IEntityTypeConfiguration<PdiStatus>
    {
        public void Configure(EntityTypeBuilder<PdiStatus> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                   .IsRequired()
                   .HasMaxLength(20);
        }
    }
}

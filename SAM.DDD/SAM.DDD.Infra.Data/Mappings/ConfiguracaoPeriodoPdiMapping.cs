using SAM.DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SAM.DDD.Infra.Data.Mappings
{
    public class ConfiguracaoPeriodoPdiMapping : IEntityTypeConfiguration<ConfiguracaoPeriodoPdi>
    {
        public void Configure(EntityTypeBuilder<ConfiguracaoPeriodoPdi> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DataInicio)
                   .IsRequired();

            builder.Property(p => p.DataFim)
                   .IsRequired();

            builder.Property(p => p.NumeroEtapa)
                   .HasColumnType("tinyint")
                   .IsRequired();
        }
    }
}

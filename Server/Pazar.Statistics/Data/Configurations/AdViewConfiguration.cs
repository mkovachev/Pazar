using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pazar.Statistics.Data.Models;

namespace Pazar.Statistics.Data.Configurations
{
    internal class AdViewConfiguration
    {
        public void Configure(EntityTypeBuilder<AdView> builder)
        {
            builder
                .HasKey(v => v.Id);

            builder
                .HasIndex(v => v.AdId);

            builder
                .Property(v => v.UserId)
                .IsRequired();
        }
    }
}

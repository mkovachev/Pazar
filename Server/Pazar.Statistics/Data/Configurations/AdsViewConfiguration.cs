using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pazar.Statistics.Data.Models;

namespace Pazar.Statistics.Data.Configurations
{
    internal class AdsViewConfiguration
    {
        public void Configure(EntityTypeBuilder<AdsView> builder)
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

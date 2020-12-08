using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pazar.Statistics.Data.Models;

namespace Pazar.Statistics.Data.Configurations
{
    internal class AdConfiguration
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
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

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pazar.Ads.Data.Models;
using static Pazar.Ads.Data.DataConstants.Image;


namespace Pazar.Ads.Data.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder
                .HasKey(i => i.Id);

            builder
              .Property(i => i.Url)
              .HasMaxLength(ImageUrlMaxLength)
              .IsRequired();

            builder
                .HasOne(i => i.Ad)
                .WithMany(ad => ad.Images)
                .HasForeignKey(ad => ad.AdId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

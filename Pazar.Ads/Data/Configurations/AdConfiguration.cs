using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pazar.Ads.Data.Models;
using static Pazar.Ads.Data.DataConstants.Ads;

namespace Pazar.Ads.Data.Configurations
{
    internal class AdConfiguration : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
             .Property(c => c.Id)
             .UseHiLo(nameof(Ad));

            builder
              .Property(ad => ad.Title)
              .HasMaxLength(TitleMaxLength)
              .IsRequired();

            builder
             .Property(ad => ad.Price)
             .HasColumnType("decimal(18,2)")
             .IsRequired();

            builder
             .Property(ad => ad.Description)
             .IsRequired()
             .HasMaxLength(DescriptionMaxLength);

            builder
             .Property(ad => ad.IsActive)
             .IsRequired();

            builder
                .HasOne(ad => ad.Category)
                .WithMany(c => c.Ads)
                .HasForeignKey(ad => ad.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(ad => ad.Customer)
                .WithMany(c => c.Ads)
                .HasForeignKey(ad => ad.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(ad => ad.Images)
                .WithOne(i => i.Ad)
                .HasForeignKey(ad => ad.AdId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

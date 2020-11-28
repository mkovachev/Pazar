using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pazar.Ads.Data.Models;
using static Pazar.Ads.Data.DataConstants.Categories;
using static Pazar.Ads.Data.DataConstants.Image;

namespace Pazar.Ads.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .HasMaxLength(NameMaxLength)
                .IsRequired();

            builder
                .Property(c => c.Image)
                .HasMaxLength(ImageUrlMaxLength)
                .IsRequired();

            builder
               .HasMany(c => c.Ads)
               .WithOne(ad => ad.Category)
               .HasForeignKey(ad => ad.CategoryId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

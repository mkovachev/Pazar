using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pazar.Ads.Data.Models;
using static Pazar.Ads.Data.DataConstants.Customers;

namespace Pazar.Ads.Data.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
             .Property(c => c.Name)
             .HasMaxLength(NameMaxLength)
             .IsRequired();

            builder
              .Property(c => c.PhoneNumber)
              .HasMaxLength(PhoneNumberMaxLength);

            builder
             .Property(c => c.UserId)
             .IsRequired();

            builder
                .HasMany(c => c.Ads)
                .WithOne(ad => ad.Customer)
                .HasForeignKey(ad => ad.CustomerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

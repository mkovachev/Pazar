using Microsoft.EntityFrameworkCore;
using Pazar.Ads.Data.Models;
using System.Reflection;

namespace Pazar.Ads
{
    public class PazarDbContext : DbContext
    {
        public PazarDbContext(DbContextOptions<PazarDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ad> Ads { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}

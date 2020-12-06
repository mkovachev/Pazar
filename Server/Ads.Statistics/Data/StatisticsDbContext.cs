using Ads.Statistics.Data.Models;
using Microsoft.EntityFrameworkCore;
using Pazar.Core.Data;
using System.Reflection;

namespace Ads.Statistics.Data
{
    public class StatisticsDbContext : MessageDbContext
    {
        public StatisticsDbContext(DbContextOptions<StatisticsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ad> Ads { get; set; }

        public DbSet<AdsStatistics> AdsStatistics { get; set; }

        protected override Assembly ConfigurationsAssembly => Assembly.GetExecutingAssembly();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}

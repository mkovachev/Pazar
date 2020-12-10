using Microsoft.EntityFrameworkCore;
using Pazar.Core.Data;
using Pazar.Statistics.Data.Models;
using System.Reflection;

namespace Pazar.Statistics.Data
{
    public class StatisticsDbContext : MessageDbContext
    {
        public StatisticsDbContext(DbContextOptions<StatisticsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ad> Ads { get; set; }

        protected override Assembly ConfigurationsAssembly => Assembly.GetExecutingAssembly();
    }
}

using Pazar.Statistics.Data.Models;
using Pazar.Core.Services.Data;
using System.Linq;

namespace Pazar.Statistics.Data
{
    public class StatisticsDataSeeder : IDataSeeder
    {
        private readonly StatisticsDbContext db;

        public StatisticsDataSeeder(StatisticsDbContext db)
        {
            this.db = db;
        }

        public void SeedData()
        {
            if (!this.db.AdsStatistics.Any())
            {
                this.db.AdsStatistics.Add(new AdsStatistics
                {
                    TotalAds = 0,
                });

                this.db.SaveChanges();
            }
        }
    }
}

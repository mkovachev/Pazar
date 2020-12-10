using Pazar.Core.Services.Data;
using Pazar.Statistics.Data.Models;
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
            if (!this.db.Ads.Any())
            {
                this.db.Ads.Add(
                    new Ad
                    {
                        Total = 0,
                    });

                this.db.SaveChanges();
            }
        }
    }
}

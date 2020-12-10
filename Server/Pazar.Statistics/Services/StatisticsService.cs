using Microsoft.EntityFrameworkCore;
using Pazar.Statistics.Data;
using System.Threading.Tasks;

namespace Pazar.Statistics.Services.Statistics
{
    public class StatisticsService : IStatisticsService
    {
        private readonly StatisticsDbContext db;

        public StatisticsService(StatisticsDbContext db)
        {
            this.db = db;
        }

        public async Task<int> All()
        {
            var ad = await this.db.Ads.FirstOrDefaultAsync();

            return ad.Total;
        }
    }
}
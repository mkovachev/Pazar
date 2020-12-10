using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pazar.Statistics.Data;
using System.Threading.Tasks;

namespace Pazar.Statistics.Services.Statistics
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IMapper mapper;
        private readonly StatisticsDbContext db;

        public StatisticsService(StatisticsDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<int> AdsOverview()
        {
            var ad = await this.db.AdsStatistics.FirstOrDefaultAsync();

            return ad.TotalAds;
        }
    }
}

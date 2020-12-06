using Ads.Statistics.Data;
using Ads.Statistics.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Ads.Statistics.Services.Statistics
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

        public async Task<StatisticsVm> AdsOverview()
            => await this.mapper
                .ProjectTo<StatisticsVm>((IQueryable)this.db.Ads.Find())
                .SingleOrDefaultAsync();
    }
}

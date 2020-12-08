using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pazar.Statistics.Data;
using Pazar.Statistics.Models;
using System.Linq;
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

        public async Task<AdsStatisticsVm> AdsOverview()
            => await this.mapper
                .ProjectTo<AdsStatisticsVm>((IQueryable)this.db.Ads.Find())
                .SingleOrDefaultAsync();
    }
}

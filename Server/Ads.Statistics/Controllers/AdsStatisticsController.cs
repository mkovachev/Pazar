using Ads.Statistics.Models;
using Ads.Statistics.Services.Statistics;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ads.Statistics.Controllers
{
    public class AdsStatisticsController
    {
        private readonly IStatisticsService adsStatistics;

        public AdsStatisticsController(IStatisticsService adsStatistics)
        {
            this.adsStatistics = adsStatistics;
        }

        [HttpGet]
        public async Task<AdsStatisticsVm> AdsOverview()
            => await this.adsStatistics.AdsOverview();
    }
}
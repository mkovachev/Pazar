using Microsoft.AspNetCore.Mvc;
using Pazar.Core.Controllers;
using Pazar.Statistics.Data.Models;
using Pazar.Statistics.Models;
using Pazar.Statistics.Services.Statistics;
using System.Threading.Tasks;

namespace Pazar.Statistics.Controllers
{
    public class AdsStatisticsController : ApiController
    {
        private readonly IStatisticsService adsStatistics;

        public AdsStatisticsController(IStatisticsService adsStatistics)
        {
            this.adsStatistics = adsStatistics;
        }

        [HttpGet]
        [Route(nameof(AdsOverview))]
        public async Task<int> AdsOverview()
            => await this.adsStatistics.AdsOverview();
    }
}
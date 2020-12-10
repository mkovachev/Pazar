using Microsoft.AspNetCore.Mvc;
using Pazar.Core.Controllers;
using Pazar.Statistics.Services.Statistics;
using System.Threading.Tasks;

namespace Pazar.Statistics.Controllers
{
    public class AdsController : ApiController
    {
        private readonly IStatisticsService adsStatistics;

        public AdsController(IStatisticsService adsStatistics)
        {
            this.adsStatistics = adsStatistics;
        }

        [HttpGet]
        public async Task<int> All()
            => await this.adsStatistics.All();
    }
}
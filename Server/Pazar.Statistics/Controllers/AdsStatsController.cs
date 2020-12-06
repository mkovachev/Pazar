using Pazar.Statistics.Models;
using Pazar.Statistics.Services.Ads;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pazar.Core.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pazar.Statistics.Controllers
{
    public class AdsStatsController : ApiController
    {
        private readonly IAdStatsService ads;

        public AdsStatsController(IAdStatsService ads)
        {
            this.ads = ads;
        }

        [HttpGet]
        [Route(Id)]
        public async Task<int> TotalViews(int id)
           => await this.ads.TotalViews(id);

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<AdVm>> TotalViews(
            [FromQuery] IEnumerable<int> ids)
            => await this.ads.TotalViews(ids);

    }
}

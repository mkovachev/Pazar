using Ads.Statistics.Models;
using Ads.Statistics.Services.Ads;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pazar.Core.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ads.Statistics.Controllers
{
    public class AdsController : ApiController
    {
        private readonly IAdService ads;

        public AdsController(IAdService ads)
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

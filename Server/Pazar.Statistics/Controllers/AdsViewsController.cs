using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pazar.Core.Controllers;
using Pazar.Statistics.Models;
using Pazar.Statistics.Services.AdsViews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pazar.Statistics.Controllers
{
    public class AdsViewsController : ApiController
    {
        private readonly IAdsViewService ads;

        public AdsViewsController(IAdsViewService ads)
        {
            this.ads = ads;
        }

        [HttpGet]
        [Route(Id)]
        public async Task<int> TotalViews(int id)
           => await this.ads.TotalViews(id);

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<AdsVm>> TotalViews(
            [FromQuery] IEnumerable<int> ids)
            => await this.ads.TotalViews(ids);

    }
}

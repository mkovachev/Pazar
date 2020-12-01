using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pazar.Ads.Models;
using Pazar.Ads.Services.Ads;
using Pazar.Core.Controllers;
using Pazar.Core.Services.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pazar.Ads.Controllers
{
    public class AdsController : ApiController
    {
        private readonly IAdService ads;
        private readonly ILoggedUserService user;

        public AdsController(IAdService ads, ILoggedUserService user)
        {
            this.ads = ads;
            this.user = user;
        }

        [HttpGet]
        public async Task<IEnumerable<AdVm>> Index()
          => await this.ads.GetAll();

        [HttpPost]
        [Authorize]
        [Route(nameof(Create))]
        public async Task<ActionResult<int>> Create(AdIm input)
            => await this.ads.Create(input);

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<AdVm>> Details(int id)
           => await this.ads.GetDetails(id);

        [HttpPut]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult<int>> Edit(int id)
            => await this.ads.Edit(id);

        [HttpDelete]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult<bool>> Delete(int id)
            => await this.ads.Delete(id);

        [HttpGet]
        [Authorize]
        [Route(nameof(MyAds))]
        public async Task<IEnumerable<AdVm>> MyAds(string id)
            => await this.ads.MyAds(id);

        [HttpGet]
        [Route(nameof(AdsPerCategory))]
        public async Task<IEnumerable<AdVm>> AdsPerCategory(int id)
           => await this.ads.GetAdsPerCategory(id);
    }
}

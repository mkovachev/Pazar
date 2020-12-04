using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pazar.Ads.Models;
using Pazar.Ads.Services.Ads;
using Pazar.Core.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pazar.Ads.Controllers
{
    public class AdsController : ApiController
    {
        private readonly IAdService ads;
        private readonly IMapper mapper;

        public AdsController(IAdService ads, IMapper mapper)
        {
            this.ads = ads;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AdVm>> Index()
          => await this.ads.GetAll();

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<AdVm>> Details(int id)
           => await this.ads.GetDetails(id);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<bool>> Create(AdCreateIm input)
            => await this.ads.Create(input);

        [HttpPut]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult<bool>> Edit(AdEditIm input)
            => await this.ads.Edit(input);

        [HttpPut]
        [Authorize]
        [Route(Id + PathSeparator + nameof(ChangeAvailability))]
        public async Task<ActionResult<bool>> ChangeAvailability(int id)
        => await this.ads.ChangeAvailability(id);

        [HttpDelete]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult<bool>> Delete(int id)
            => await this.ads.Delete(id);

        [HttpGet]
        [Authorize]
        [Route(nameof(MyAds))]
        public async Task<IEnumerable<AdVm>> MyAds(string userId)
            => await this.ads.MyAds(userId);

        [HttpGet]
        [Route(nameof(AdsPerCategory))]
        public async Task<IEnumerable<AdVm>> AdsPerCategory(int id)
           => await this.ads.GetAdsPerCategory(id);
    }
}

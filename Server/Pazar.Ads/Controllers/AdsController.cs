using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Pazar.Ads.Data.Models;
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
        public async Task<ActionResult<int>> Create(AdCreateIm input)
            => await this.ads.Create(input);

        [HttpPut]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult<int>> Edit(AdEditIm input, int id)
            => await this.ads.Edit(input, id);

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

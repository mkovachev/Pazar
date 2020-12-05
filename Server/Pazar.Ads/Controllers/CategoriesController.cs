using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pazar.Ads.Models;
using Pazar.Ads.Services.Categories;
using Pazar.Core.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pazar.Ads.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService categories;

        public CategoriesController(ICategoryService categories)
        {
            this.categories = categories;
        }

        [HttpGet]
        [Authorize]
        [Route(Id)]
        public async Task<CategoryDetailsVm> Find(int id)
            => await this.categories.Find(id);


        [HttpGet]
        public async Task<IEnumerable<CategoryVm>> Index()
            => await this.categories.All();


        [HttpGet]
        [Route(Id + PathSeparator + nameof(Ads))]
        public async Task<IEnumerable<AdVm>> Ads(int id)
            => await this.categories.Ads(id);
    }
}

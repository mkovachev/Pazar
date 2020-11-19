using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pazar.Ads.Features.Categories.Models;
using Pazar.Ads.Services.Categories;
using Pazar.Core.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pazar.Ads.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryService categories;

        public CategoryController(ICategoryService categories)
        {
            this.categories = categories;
        }

        [HttpGet]
        [Authorize]
        [Route(Id)]
        public async Task<CategoryDetailsVm> Find(int id)
            => await this.categories.FindById(id);


        [HttpGet]
        [Route(nameof(Categories))]
        public async Task<IEnumerable<CategoryVm>> Categories()
            => await this.categories.GetAll();

    }
}

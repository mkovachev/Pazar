using Microsoft.AspNetCore.Mvc;
using Pazar.Ads.Features.Categories.Models;
using Pazar.Ads.Features.Categories.Queries;
using Pazar.Core.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pazar.Ads.Controllers
{
    public class CategoryController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryVm>>> Index(
          [FromQuery] GetCategoriesQuery query)
        {
            var categories = await Mediator.Send(query);
            return Ok(categories);
        }

    }
}

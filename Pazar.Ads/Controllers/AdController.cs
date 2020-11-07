using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pazar.Ads.Features.Ads.Commands;
using Pazar.Ads.Features.Ads.Models;
using Pazar.Ads.Features.Ads.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pazar.Ads.Controllers
{
    public class AdController : ApiController
    {
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> Create(CreateAdCommand command)
            => await Mediator.Send(command);


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateAdCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteAdCommand { Id = id });

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryVm>>> Index(
              [FromQuery] GetCategoriesQuery query)
        {
            var categories = await Mediator.Send(query);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AdVm>>> Category(
           [FromQuery] GetAdsPerCategory query)
        {
            var adsGetAdsPerCategory = await Mediator.Send(query);
            return Ok(adsGetAdsPerCategory);
        }
    }
}

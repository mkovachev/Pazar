using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pazar.Ads.Features.Ads.Commands;
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
    }
}

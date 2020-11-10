using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pazar.Core.Controllers;
using Pazar.Core.Services.Identity;
using Pazar.Identity.Models;
using Pazar.Identity.Services;
using System.Threading.Tasks;

namespace Pazar.Identity.Controllers
{
    public class IdentityController : ApiController
    {
        private readonly IIdentityService identity;
        private readonly IUserService currentUser;

        public IdentityController(
            IIdentityService identity,
            IUserService currentUser)
        {
            this.identity = identity;
            this.currentUser = currentUser;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult<UserOutputModel>> Register(UserInputModel input)
        {
            var result = await this.identity.Register(input);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return await Login(input);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<UserOutputModel>> Login(UserInputModel input)
        {
            var result = await this.identity.Login(input);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return new UserOutputModel(result.Data.Token);
        }

        [HttpPut]
        [Authorize]
        [Route(nameof(ChangePassword))]
        public async Task<ActionResult> ChangePassword(ChangePasswordInputModel input)
            => await this.identity.ChangePassword(this.currentUser.Id, new ChangePasswordInputModel
            {
                CurrentPassword = input.CurrentPassword,
                NewPassword = input.NewPassword
            });
    }
}

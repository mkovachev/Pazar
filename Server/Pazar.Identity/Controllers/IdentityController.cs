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
        private readonly IUserService user;

        public IdentityController(IIdentityService identity, IUserService user)
        {
            this.identity = identity;
            this.user = user;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult<UserVm>> Register(UserIm input)
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
        public async Task<ActionResult<UserVm>> Login(UserIm input)
        {
            var result = await this.identity.Login(input);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors); // return Unauthorized();
            }

            return new UserVm(result.Data.Token);
        }

        [HttpPut]
        [Authorize]
        [Route(nameof(ChangePassword))]
        public async Task<ActionResult> ChangePassword(ChangePasswordIm input)
            => await this.identity.ChangePassword(
                this.user.Id,
                new ChangePasswordIm
                {
                    CurrentPassword = input.CurrentPassword,
                    NewPassword = input.NewPassword
                });

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route(nameof(Delete))]
        public async Task<ActionResult> Delete()
        {
            var result = await this.identity.DeleteUser(this.user.Id);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }
    }
}

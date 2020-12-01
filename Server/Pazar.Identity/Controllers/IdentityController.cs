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
        private readonly ILoggedUserService user;

        public IdentityController(IIdentityService identity, ILoggedUserService user)
        {
            this.identity = identity;
            this.user = user;
        }


        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<string>> GetId()
            => await this.identity.GetId();

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

            return new UserVm(result.Data.Token); // result.Data.Id
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
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

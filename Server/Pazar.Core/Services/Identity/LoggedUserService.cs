using Microsoft.AspNetCore.Http;
using Pazar.Core.Services.Data;
using System.Collections.Generic;
using System.Security.Claims;

namespace Pazar.Core.Services.Identity
{
    using static DataConstants.Identity;
    public class LoggedUserService : ILoggedUserService
    {
        private readonly ClaimsPrincipal user;
        private readonly IHttpContextAccessor accessor;
        public LoggedUserService(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
            //this.user = this.accessor.HttpContext?.User;

            //if (this.user == null)
            //{
            //    throw new InvalidOperationException("No authenticated user found");
            //}

            //this.Id = this.user.FindFirstValue(ClaimTypes.NameIdentifier);

            //this.Name = this.user.FindFirstValue(ClaimTypes.Name);

            //this.IsAdministrator = this.user.IsInRole(AdminRole);
        }

        public string Id => this.accessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        public string Name => this.accessor.HttpContext?.User?.Identity.Name;

        public bool IsAdministrator => (bool)(this.accessor.HttpContext?.User?.IsInRole(AdminRole));

        public bool IsAuthenticated() => (bool)(this.accessor.HttpContext?.User?.Identity.IsAuthenticated);

        public IEnumerable<Claim> GetClaimsIdentity() => this.accessor.HttpContext?.User?.Claims;

    }
}

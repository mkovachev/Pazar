using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;

namespace Pazar.Core.Services.Identity
{
    public class LoggedUserService : ILoggedUserService
    {
        private readonly IHttpContextAccessor accessor;
        public LoggedUserService(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
        }

        public string? Id => this.accessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        public string? Name => this.accessor.HttpContext?.User?.Identity.Name;

        //public bool IsAdministrator => (bool)(this.accessor.HttpContext?.User?.IsInRole(AdminRole));

        public bool IsAuthenticated() => (bool)(this.accessor.HttpContext?.User?.Identity?.IsAuthenticated);

        public IEnumerable<Claim> GetClaimsIdentity() => this.accessor.HttpContext?.User?.Claims;

    }
}

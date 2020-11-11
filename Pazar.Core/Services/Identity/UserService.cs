using Microsoft.AspNetCore.Http;
using Pazar.Core.Data;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Pazar.Core.Services.Identity
{
    using static DataConstants.Identity;

    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor accessor;
        private readonly ClaimsPrincipal user;
        public UserService(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
            this.user = accessor.HttpContext?.User;

            if (user == null)
            {
                throw new InvalidOperationException("This request does not have an authenticated user.");
            }
        }

        public string Id => this.accessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        public string Name => this.accessor.HttpContext?.User.Identity.Name;

        public bool IsAuthenticated() => this.accessor.HttpContext.User.Identity.IsAuthenticated;

        public IEnumerable<Claim> GetClaimsIdentity() => this.accessor.HttpContext?.User.Claims;

        public bool IsAdministrator => this.user.IsInRole(AdminRole);
    }
}

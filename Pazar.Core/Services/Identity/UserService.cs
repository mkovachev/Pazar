using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Pazar.Core.Data;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Pazar.Core.Services.Identity
{
    using static DataConstants.Identity;

    public class UserService : IUserService
    {
        private readonly ClaimsPrincipal user;
        private readonly IHttpContextAccessor accessor;
        private readonly UserManager<User> userManager;
        public UserService(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
            this.user = this.accessor.HttpContext?.User;

            if (this.user == null)
            {
                throw new InvalidOperationException("This request does not have an authenticated user.");
            }

            this.Id = this.accessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string Id { get; }

        public string Name => this.accessor.HttpContext?.User.Identity.Name;

        public bool IsAuthenticated() => this.accessor.HttpContext.User.Identity.IsAuthenticated;

        public IEnumerable<Claim> GetClaimsIdentity() => this.accessor.HttpContext?.User.Claims;

        public bool IsAdministrator => this.user.IsInRole(AdminRole);

    }
}

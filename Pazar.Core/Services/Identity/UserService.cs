using Microsoft.AspNetCore.Http;
using Pazar.Core.Services.Data;
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
        public UserService(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
            this.user = this.accessor.HttpContext?.User;

            if (this.user == null)
            {
                throw new InvalidOperationException("No authenticated user found");
            }

            this.Id = this.user.FindFirstValue(ClaimTypes.NameIdentifier); // Todo

            this.Name = this.user.FindFirstValue(ClaimTypes.Name);

            this.IsAdministrator = this.user.IsInRole(AdminRole);
        }

        public string Id { get; } // => this.user.FindFirstValue(ClaimTypes.NameIdentifier);

        public string Name { get; } // => this.accessor.HttpContext?.User.Identity.Name;

        public bool IsAdministrator { get; } //=> this.user.IsInRole(AdminRole);

        public bool IsAuthenticated() => this.accessor.HttpContext.User.Identity.IsAuthenticated;

        public IEnumerable<Claim> GetClaimsIdentity() => this.accessor.HttpContext?.User.Claims;


    }
}

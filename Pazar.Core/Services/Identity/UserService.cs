using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Pazar.Core.Services.Identity
{
    internal class UserService : IUser
    {
        private readonly IHttpContextAccessor accessor;
        public UserService(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
        }

        public string Id => this.accessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        public string Name => this.accessor.HttpContext?.User.Identity.Name;

        public bool IsAuthenticated() => this.accessor.HttpContext.User.Identity.IsAuthenticated;

        public IEnumerable<Claim> GetClaimsIdentity() => this.accessor.HttpContext?.User.Claims;

        public bool IsAdministrator => throw new NotImplementedException();
    }
}

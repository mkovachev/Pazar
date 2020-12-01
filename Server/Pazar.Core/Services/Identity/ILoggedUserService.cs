using System.Collections.Generic;
using System.Security.Claims;

namespace Pazar.Core.Services.Identity
{
    public interface ILoggedUserService
    {
        string Id { get; }

        string Name { get; }

        bool IsAuthenticated();

        IEnumerable<Claim> GetClaimsIdentity();

        //bool IsAdministrator { get; }
    }
}

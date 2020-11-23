using System.Security.Claims;

namespace Pazar.Core.Extensions
{
    using static Constants;
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsAdministrator(this ClaimsPrincipal user)
            => user.IsInRole(Admin);
    }
}

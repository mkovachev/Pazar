using Microsoft.AspNetCore.Authorization;

namespace Pazar.Core.Extensions
{
    using static Constants;
    public class AuthorizeAdminAttribute : AuthorizeAttribute
    {
        public AuthorizeAdminAttribute()
        {
            this.Roles = Admin;
        }
    }
}

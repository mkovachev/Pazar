using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Pazar.Identity.Data;
using Pazar.Identity.Data.Models;

namespace Pazar.Identity.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUserStorage(
            this IServiceCollection services)
        {
            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                    .AddEntityFrameworkStores<IdentityDbContext>();

            return services;
        }
    }
}

using Microsoft.Extensions.Configuration;

namespace Pazar.Core.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetDefaultConnectionString(this IConfiguration configuration)
            => configuration.GetConnectionString("DefaultConnection");

        public static string GetCronJobsConnectionString(this IConfiguration configuration)
            => configuration.GetConnectionString("CronJobsConnection");
    }
}

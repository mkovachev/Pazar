using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Pazar.Watchdog
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddHealthChecksUI()
                .AddInMemoryStorage();
            //.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pazar.Watchdog", Version = "v1" });
            //});
        }

        public void Configure(IApplicationBuilder app)
        {
            app
                .UseRouting()
                .UseEndpoints(endpoints => endpoints
                    .MapHealthChecksUI(healthChecks => healthChecks
                        .UIPath = "/healthchecks"));
        }
    }
}

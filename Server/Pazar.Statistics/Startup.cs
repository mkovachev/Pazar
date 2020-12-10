using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pazar.Core.Extensions;
using Pazar.Statistics.Data;
using Pazar.Statistics.Messages;
using Pazar.Statistics.Services.Statistics;

namespace Pazar.Statistics
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
      => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddWebService<StatisticsDbContext>(this.Configuration)
                .AddTransient<IStatisticsService, StatisticsService>()
                .AddMessaging(
                    this.Configuration,
                    consumers: typeof(AdCreatedConsumer))
                .AddSwaggerWithJwt();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env);
    }
}

using Ads.Statistics.Data;
using Ads.Statistics.Messages;
using Ads.Statistics.Services.Ads;
using Ads.Statistics.Services.Statistics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pazar.Core.Extensions;
using Pazar.Core.Services.Data;

namespace Ads.Statistics
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
      => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddWebService<StatisticsDbContext>(this.Configuration)
                .AddTransient<IDataSeeder, StatisticsDataSeeder>()
                .AddTransient<IStatisticsService, StatisticsService>()
                .AddTransient<IAdService, AdService>()
                .AddMessaging(
                    this.Configuration,
                    consumers: typeof(AdCreatedConsumer));

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }
}

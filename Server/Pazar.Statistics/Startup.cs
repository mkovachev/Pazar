using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pazar.Core.Extensions;
using Pazar.Core.Services.Data;
using Pazar.Statistics.Data;
using Pazar.Statistics.Messages;
using Pazar.Statistics.Services.Ads;
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
                .AddTransient<IDataSeeder, StatisticsDataSeeder>()
                .AddTransient<IStatisticsService, StatisticsService>()
                .AddTransient<IAdService, AdService>()
                .AddMessaging(
                    this.Configuration,
                    consumers: typeof(AdCreatedConsumer))
                .AddSwaggerWithJwt();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }
}

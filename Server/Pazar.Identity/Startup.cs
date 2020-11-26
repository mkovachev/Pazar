using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pazar.Core.Extensions;
using Pazar.Core.Services.Data;
using Pazar.Identity.Data;
using Pazar.Identity.Extensions;
using Pazar.Identity.Services;

namespace Pazar.Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .Configure<IdentitySettings>(
                    this.Configuration.GetSection(nameof(IdentitySettings)),
                    config => config.BindNonPublicProperties = true)
                .AddWebService<IdentityDbContext>(this.Configuration, messagingHealthChecks: false)
                .AddUserStorage()
                .AddTransient<IDataSeeder, IdentityDataSeeder>()
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<ITokenGeneratorService, TokenGeneratorService>()
                .AddSwaggerWithJwt();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
                    => app
                        .UseWebService(env)
                        .Initialize();
    }
}

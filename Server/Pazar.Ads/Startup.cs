using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Pazar.Ads.Data;
using Pazar.Ads.Data.Interfaces;
using Pazar.Ads.Data.Models;
using Pazar.Ads.Infrastructure;
using Pazar.Ads.Services.Ads;
using Pazar.Ads.Services.Categories;
using Pazar.Core.Extensions;
using Pazar.Core.Interfaces;
using Pazar.Core.Services.Data;

namespace Pazar.Ads
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
                    .AddWebService<PazarDbContext>(this.Configuration)
                    .AddTransient<IDataSeeder, AdsDataSeeder>()
                    .AddTransient<IAdService, AdService>()
                    .AddTransient<ICategoryService, CategoryService>()
                    .AddTransient<IInitialCategories, CategoryData>()
                    .AddSingleton<IDateTime, DateTimeProvider>()
                    .AddSwaggerGen(c =>
                    {
                        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pazar.Ads", Version = "v1" });
                    });



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
                    => app
                        .UseWebService(env)
                        .Initialize();
    }
}

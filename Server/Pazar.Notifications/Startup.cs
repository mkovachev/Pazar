using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pazar.Core.Data;
using Pazar.Core.Extensions;
using Pazar.Notifications.Hubs;
using Pazar.Notifications.Infrastructure;
using Pazar.Notifications.Messages;

namespace Pazar.Notifications
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddCors()
                .AddScoped<DbContext, MessageDbContext>()
                .AddDbContext<MessageDbContext>()
                .AddTokenAuthentication(
                    this.Configuration,
                    JwtConfiguration.BearerEvents)
                .AddHealth(
                    this.Configuration,
                    databaseHealthChecks: false)
                .AddMessaging(
                    this.Configuration,
                    usePolling: false,
                    consumers: typeof(AdCreatedConsumer))
                .AddSignalR();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var allowedOrigins = this.Configuration
                .GetSection(nameof(NotificationSettings))
                .GetValue<string>(nameof(NotificationSettings.AllowedOrigins));

            app
                .UseRouting()
                .UseCors(options => options
                    .WithOrigins(allowedOrigins)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints
                    .MapHealthChecks()
                    .MapHub<NotificationsHub>("/notifications"));
        }
    }
}

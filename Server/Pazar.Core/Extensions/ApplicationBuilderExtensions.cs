﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pazar.Core.Services.Data;

namespace Pazar.Core.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseWebService(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pazar v1"));
            }

            app
                .UseRouting()
                .UseCors(options => options
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints
                                             .MapHealthChecks()
                                             .MapControllers());

            return app;
        }

        public static IApplicationBuilder Initialize(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var serviceProvider = serviceScope.ServiceProvider;

            var db = serviceProvider.GetRequiredService<DbContext>();

            db.Database.Migrate();

            var seeders = serviceProvider.GetServices<IDataSeeder>();

            foreach (var seeder in seeders)
            {
                seeder.SeedData();
            }

            return app;
        }
    }
}

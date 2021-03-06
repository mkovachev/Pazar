﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Pazar.Core;
using Pazar.Core.Services.Data;
using Pazar.Identity.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Pazar.Identity.Data
{
    using static DataConstants.Identity;
    public class IdentityDataSeeder : IDataSeeder
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly AppSettings applicationSettings;
        private readonly IdentitySettings identitySettings;

        public IdentityDataSeeder(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<AppSettings> applicationSettings,
            IOptions<IdentitySettings> identitySettings)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.applicationSettings = applicationSettings.Value;
            this.identitySettings = identitySettings.Value;
        }

        public void SeedData()
        {
            if (!this.roleManager.Roles.Any())
            {
                Task
                    .Run(async () =>
                    {
                        var adminRole = new IdentityRole(AdminRole);

                        await this.roleManager.CreateAsync(adminRole);

                        var adminUser = new User
                        {
                            UserName = "admin@mail.com",
                            Email = "admin@mail.com",
                            SecurityStamp = "SomeSecurityStamp"
                        };

                        await this.userManager.CreateAsync(adminUser, this.identitySettings.AdminPassword);

                        await this.userManager.AddToRoleAsync(adminUser, AdminRole);
                    })
                    .GetAwaiter()
                    .GetResult();
            }

            if (this.applicationSettings.SeedInitialData)
            {
                Task
                    .Run(async () =>
                    {
                        if (await this.userManager.FindByIdAsync(DataSeederConstants.DefaultUserId) != null)
                        {
                            return;
                        }

                        var defaultUser = new User
                        {
                            Id = DataSeederConstants.DefaultUserId,
                            UserName = "user@mail.com",
                            Email = "user@mail.com"
                        };

                        await this.userManager.CreateAsync(defaultUser, DataSeederConstants.DefaultUserPassword);
                    })
                    .GetAwaiter()
                    .GetResult();
            }
        }
    }
}

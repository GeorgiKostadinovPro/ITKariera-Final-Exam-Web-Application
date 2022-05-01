using AirConditionersManagementSystem.Common;
using AirConditionersManagementSystem.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionersManagementSystem.Data.Seeding
{
    public class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (dbContext.Users.Any())
            {
                return;
            }

            ApplicationUser administrator = new ApplicationUser
            {
                UserName = "GergiK",
                PasswordHash = "Gk034714.",
                Email = "georgikostadinov14@abv.bg",
            };

            ApplicationUser technician = new ApplicationUser
            {
                UserName = "Peter",
                PasswordHash = "Peter12345.",
                Email = "peter10@abv.bg",
            };

            ApplicationUser client = new ApplicationUser
            {
                UserName = "Client",
                PasswordHash = "Client%1234560",
                Email = "client@abv.bg",
            };

            await userManager.CreateAsync(administrator, administrator.PasswordHash);
            await userManager.CreateAsync(technician, technician.PasswordHash);
            await userManager.CreateAsync(client, client.PasswordHash);

            await userManager.AddToRoleAsync(administrator, GlobalConstants.AdministratorRoleName);
            await userManager.AddToRoleAsync(technician, GlobalConstants.TechnicialRoleName);
            await userManager.AddToRoleAsync(client, GlobalConstants.ClientRoleName);
        }
    }
}

namespace Ivteks72.Data.Seeding
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    using Ivteks72.Domain;
    using Ivteks72.Common;

    public class AdminSeeder : ISeeder
    {
        public async Task SeedAsync(Ivteks72DbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedRoleAsync(userManager);
        }

        private async Task SeedRoleAsync(UserManager<ApplicationUser> userManager)
        {
            var administrator = new ApplicationUser
            {
                Email = "ivtex72@abv.bg",
                UserName = "PetyrIv",
                FullName = "Petyr Ivanov",
                Company = new Company
                {
                    Name = "Ivteks72",
                    Address = "Pazardzhik"
                },

            };

            var result = await userManager.CreateAsync(administrator, GlobalConstants.AdministratorPassword);

            if (result.Succeeded)
            {
                var newUserRole = userManager.AddToRoleAsync(administrator, GlobalConstants.AdministratorRoleName);
                newUserRole.Wait();
            }
        }
    }
}

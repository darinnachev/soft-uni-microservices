using System.Linq;
using System.Threading.Tasks;
using Homebook.Services;
using Microsoft.AspNetCore.Identity;
using Homebook.Identity.Data.Models;

namespace Homebook.Identity.Data
{
    public class IdentityDataSeeder : IDataSeeder
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public IdentityDataSeeder(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void SeedData()
        {
            if (this.roleManager.Roles.Any())
            {
                return;
            }

            Task
                .Run(async () =>
                {
                    var adminRole = new IdentityRole(Constants.AdministratorRoleName);

                    await this.roleManager.CreateAsync(adminRole);

                    adminRole = new IdentityRole(Constants.ClientRoleName);

                    await this.roleManager.CreateAsync(adminRole);

                    var adminUser = new User
                    {
                        UserName = "asd@asd.com",
                        Email = "asd@asd.com",
                        SecurityStamp = "stamp"
                    };

                    await userManager.CreateAsync(adminUser, "adminpass12");

                    await userManager.AddToRoleAsync(adminUser, Constants.AdministratorRoleName);

                    //
                    var user1 = new User
                    {
                        UserName = "user1@abv.bg",
                        Email = "user1@abv.bg",
                        SecurityStamp = "stamp"
                    };

                    await userManager.CreateAsync(user1, "adminpass12");

                    await userManager.AddToRoleAsync(user1, Constants.ClientRoleName);

                    //
                    var user2 = new User
                    {
                        UserName = "user2@abv.bg",
                        Email = "user2@abv.bg",
                        SecurityStamp = "stamp"
                    };

                    await userManager.CreateAsync(user2, "adminpass12");

                    await userManager.AddToRoleAsync(user2, Constants.ClientRoleName);

                })
                .GetAwaiter()
                .GetResult();
        }
    }
}

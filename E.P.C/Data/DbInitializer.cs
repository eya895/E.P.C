using Microsoft.AspNetCore.Identity;

namespace E.P.C.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAdminAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

            const string adminRole = "Admin";
            const string adminEmail = "admin@epc.com";
            const string adminPassword = "Admin123!";

            // Create role if not exists
            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            // Create admin user if not exists
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(adminUser, adminPassword);
                await userManager.AddToRoleAsync(adminUser, adminRole);
            }
        }
    }
}


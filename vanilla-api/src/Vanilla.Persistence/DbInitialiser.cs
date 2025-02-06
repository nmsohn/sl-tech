using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Vanilla.Domain.Entities.Enums;

namespace Vanilla.Persistence
{
    public class DbInitialiser(ILogger<DbInitialiser> logger, VanillaDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        public async Task InitialiseAsync()
        {
            try
            {
                if (context.Database.IsSqlServer())
                {
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }
        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }
        public async Task TrySeedAsync()
        {
            // Default roles
            var administratorRole = new IdentityRole(RoleType.Admin.ToString());

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                var role = await roleManager.CreateAsync(administratorRole);
                if (role != null)
                {
                    await roleManager.AddClaimAsync(administratorRole, new Claim("RoleClaim", "HasRoleView"));
                    await roleManager.AddClaimAsync(administratorRole, new Claim("RoleClaim", "HasRoleAdd"));
                    await roleManager.AddClaimAsync(administratorRole, new Claim("RoleClaim", "HasRoleEdit"));
                    await roleManager.AddClaimAsync(administratorRole, new Claim("RoleClaim", "HasRoleDelete"));
                }
            }

            // Default users
            var administrator = new AppUser { UserName = "admin", Email = "admin@gmail.com" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "admin");
                if (!string.IsNullOrWhiteSpace(administratorRole.Name))
                {
                    await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
                }
            }
            
            // await context.Users.AddRangeAsync(users);
            // await context.SaveChangesAsync();
        }
    }
}
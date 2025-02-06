using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Vanilla.Persistence;

public class VanillaDbContext(DbContextOptions<VanillaDbContext> options) : DbContext
    // : IdentityDbContext<AppUser, AppRole, Guid>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
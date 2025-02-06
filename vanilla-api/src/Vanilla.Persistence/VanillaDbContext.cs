using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Vanilla.Persistence;

public class VanillaDbContext(DbContextOptions<VanillaDbContext> options)
    : IdentityDbContext<AppUser, AppRole, Guid>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
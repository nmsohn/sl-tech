using System.Reflection;

namespace Vanilla.Persistence;

public class VanillaDbContext : DbContext
{
    // could be replaced by using IdentityDbContext
    public DbSet<User> Users { get; set; } 
    public DbSet<Role> Roles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
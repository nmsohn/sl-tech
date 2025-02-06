using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Vanilla.Persistence;

public class VanillaDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
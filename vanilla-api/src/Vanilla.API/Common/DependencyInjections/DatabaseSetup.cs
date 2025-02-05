using Microsoft.EntityFrameworkCore;
using Vanilla.Persistence;

namespace Vanilla.API.Common.DependencyInjections;

public static class DatabaseSetup
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<VanillaDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServerDb"))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        });
        
        return services;
    }
}
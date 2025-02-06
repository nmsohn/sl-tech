using Microsoft.EntityFrameworkCore;
using Vanilla.Persistence;

namespace Vanilla.API.Common.Extensions;

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
        
        // services.AddScoped<ISession, Session>();
        // services
        //     .AddIdentityApiEndpoints<AppUser>()
        //     .AddEntityFrameworkStores<VanillaDbContext>();
        
        return services;
    }
}
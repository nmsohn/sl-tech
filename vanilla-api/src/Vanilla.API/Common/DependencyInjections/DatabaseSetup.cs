using Microsoft.EntityFrameworkCore;
using Vanilla.Application.Auth;
using Vanilla.Domain.Entities;
using Vanilla.Persistence;
using ISession = Vanilla.Application.Auth.ISession;

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
        
        services.AddScoped<ISession, Session>();
        
        // services
        //     .AddIdentityApiEndpoints<AppUser>()
        //     .AddEntityFrameworkStores<VanillaDbContext>();
        
        return services;
    }
}
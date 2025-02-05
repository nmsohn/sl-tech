using Vanilla.Application.Mapping;

namespace Vanilla.API.Common.DependencyInjections;

public static class ApplicationSetup
{
    public static IServiceCollection Setup(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(UserProfile).Assembly);
        
        return services;
    }
}
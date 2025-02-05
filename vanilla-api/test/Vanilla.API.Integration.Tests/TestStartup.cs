using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vanilla.Persistence;

namespace Vanilla.API.Integration.Tests;

public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test");
        builder.ConfigureServices(services =>
        {
            var dbContext = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(VanillaDbContext));
            
            if (dbContext != null)
            {
                services.Remove(dbContext);
                var options = services.Where(r => r.ServiceType == typeof(DbContextOptions)
                                                  || r.ServiceType.IsGenericType && r.ServiceType.GetGenericTypeDefinition() == typeof(DbContextOptions<>)).ToArray();
                foreach (var option in options)
                {
                    services.Remove(option);
                }
            }

            services.AddDbContext<VanillaDbContext>(options =>
            {
                options.UseInMemoryDatabase("TestDatabase");
            });
        });
    }
}
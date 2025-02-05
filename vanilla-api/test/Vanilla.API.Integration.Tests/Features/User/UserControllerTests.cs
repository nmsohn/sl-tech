using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Vanilla.Persistence;
using Xunit;

namespace Vanilla.API.Integration.Tests.Features.User;

public class UserControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;
    private HttpClient _httpClient;
    
    public UserControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _httpClient = _factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }
}
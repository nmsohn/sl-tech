using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using Vanilla.API.Integration.Tests.Common;
using Xunit;
using Assert = Xunit.Assert;

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

    [Fact]
    public async Task Can_Create_User()
    {
        var _request= new 
        {
        };

        var content = new StringContent(JsonConvert.SerializeObject(_request), Encoding.UTF8,
            MediaTypeNames.Application.Json);
        
        var response= await _httpClient.PostAsync("", content);
        
        // if (response.IsSuccessStatusCode)
        // {
        //     response.Should().NotBeNull();
        //     var userLoginResponse = await response.Content.ReadFromJsonAsync<TestResponse<response>>();
        //     userLoginResponse.Should().NotBeNull();
        //     userLoginResponse?.IsSucceed.Should().BeTrue();
        //     userLoginResponse?.Data.Should().NotBeNull();
        //     userLoginResponse?.Data?.AccessToken.Should().NotBeNull();
        //     userLoginResponse?.Data?.RefreshToken.Should().NotBeNull();
        // }
        // else
        // {
        //     Assert.Fail("Api call failed.");
        // }
    }
}
using Api.ProtectionPlusInsurance;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Tests.ProtectionPlusInsurance
{
    public class ClaimStatusControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ClaimStatusControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateClaimStatus_WhenValid_ReturnsOkAndNewId() 
            => await TestHelpers.CreateClaimStatus_Test(_client);
    }
}

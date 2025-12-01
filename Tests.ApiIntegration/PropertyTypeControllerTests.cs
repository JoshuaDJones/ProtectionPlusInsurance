using Api.ProtectionPlusInsurance;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests.ProtectionPlusInsurance
{
    public class PropertyTypeControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public PropertyTypeControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreatePropertyType_WhenValid_ReturnsOkAndNewId()
            => await TestHelpers.CreatePropertyType_Test(_client);
    }
}

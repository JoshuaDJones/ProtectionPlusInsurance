using Api.ProtectionPlusInsurance;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests.ProtectionPlusInsurance
{
    public class PropertyControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public PropertyControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateProperty_WhenValid_ReturnsOkAndNewId()
        {
            var policyHolderId = await TestHelpers.CreatePolicyHolder_Test(_client);
            var propertyTypeId = await TestHelpers.CreatePropertyType_Test(_client);
            await TestHelpers.CreateProperty_Test(_client, policyHolderId, propertyTypeId);            
        }
    }
}

using Api.ProtectionPlusInsurance;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests.ProtectionPlusInsurance
{
    public class PolicyControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public PolicyControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreatePolicy_WhenValid_ReturnsOkAndNewId()
        {
            var policyHolderId = await TestHelpers.CreatePolicyHolder_Test(_client);
            var policyStatusId = await TestHelpers.CreatePolicyStatus_Test(_client, policyHolderId);
            var propertyTypeId = await TestHelpers.CreatePropertyType_Test(_client);
            var propertyId = await TestHelpers.CreateProperty_Test(_client, policyHolderId, propertyTypeId);
            await TestHelpers.CreatePolicy_Test(_client, policyHolderId, policyStatusId, propertyId);
        }
    }
}

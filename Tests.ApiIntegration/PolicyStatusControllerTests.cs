using Api.ProtectionPlusInsurance;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests.ProtectionPlusInsurance
{
    public class PolicyStatusControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public PolicyStatusControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreatePolicyStatus_WhenValid_ReturnsOkAndNewId()
        {
            var policyHolderId = await TestHelpers.CreatePolicyHolder_Test(_client);
            await TestHelpers.CreatePolicyStatus_Test(_client, policyHolderId);
        }
    }
}

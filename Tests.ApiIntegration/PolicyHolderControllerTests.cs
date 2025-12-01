using Api.ProtectionPlusInsurance;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests.ProtectionPlusInsurance
{
    public class PolicyHolderControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public PolicyHolderControllerTest(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreatePolicyHolder_WhenValid_ReturnsOkAndNewId()
            => await TestHelpers.CreatePolicyHolder_Test(_client);
    }
}

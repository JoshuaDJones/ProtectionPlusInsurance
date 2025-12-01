using Api.ProtectionPlusInsurance;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests.ProtectionPlusInsurance
{
    public class IncidentControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public IncidentControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateIncident_WhenValid_ReturnsOkAndNewId()
        {
            var incidentTypeId = await TestHelpers.CreateIncidentType_Test(_client);
            var policyHolderId = await TestHelpers.CreatePolicyHolder_Test(_client);
            var policyStatusId = await TestHelpers.CreatePolicyStatus_Test(_client, policyHolderId);
            var propertyTypeId = await TestHelpers.CreatePropertyType_Test(_client);
            var propertyId = await TestHelpers.CreateProperty_Test(_client, policyHolderId, propertyTypeId);
            var policyId = await TestHelpers.CreatePolicy_Test(_client, policyHolderId, policyStatusId, propertyId);
            await TestHelpers.CreateIncident_Test(_client, policyId, incidentTypeId);
        }
    }
}

using Api.ProtectionPlusInsurance;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Tests.ProtectionPlusInsurance
{
    public class ClaimAdjusterController : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ClaimAdjusterController(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateClaimAdjuster_WhenValid_ReturnsOkAndNewId()
        {
            var adjusterId = await TestHelpers.CreateAdjuster_Test(_client);
            var claimStatusId = await TestHelpers.CreateClaimStatus_Test(_client);
            var incidentTypeId = await TestHelpers.CreateIncidentType_Test(_client);
            var policyHolderId = await TestHelpers.CreatePolicyHolder_Test(_client);
            var policyStatusId = await TestHelpers.CreatePolicyStatus_Test(_client, policyHolderId);
            var propertyTypeId = await TestHelpers.CreatePropertyType_Test(_client);
            var propertyId = await TestHelpers.CreateProperty_Test(_client, policyHolderId, propertyTypeId);
            var policyId = await TestHelpers.CreatePolicy_Test(_client, policyHolderId, policyStatusId, propertyId);
            var incidentId = await TestHelpers.CreateIncident_Test(_client, policyId, incidentTypeId);
            var claimId = await TestHelpers.CreateClaim_Test(_client, incidentId, claimStatusId);
            await TestHelpers.CreateClaimAdjuster_Test(_client, claimId, adjusterId);
        }
    }
}

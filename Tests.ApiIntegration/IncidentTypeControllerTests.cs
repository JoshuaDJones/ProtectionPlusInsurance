using Api.ProtectionPlusInsurance;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests.ProtectionPlusInsurance
{
    public class IncidentTypeControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public IncidentTypeControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateIncidentType_WhenValid_ReturnsOkAndNewId()
            => await TestHelpers.CreateIncidentType_Test(_client);
    }
}

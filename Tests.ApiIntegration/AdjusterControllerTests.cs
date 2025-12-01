using Api.ProtectionPlusInsurance;
using Api.ProtectionPlusInsurance.Requests.Adjuster;
using Application.ProtectionPlusInsurance.Dtos;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;

namespace Tests.ProtectionPlusInsurance
{
    public class AdjusterControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AdjusterControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateAdjuster_WhenValid_ReturnsOkAndNewId()
        {
            await TestHelpers.CreateAdjuster_Test(_client);
        }
    }
}

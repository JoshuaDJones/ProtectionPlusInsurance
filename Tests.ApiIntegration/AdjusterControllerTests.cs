using Api.ProtectionPlusInsurance;
using Api.ProtectionPlusInsurance.Requests.Adjuster;
using Azure.Core;
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
        public async Task CreateAdjuster_ReturnsOk()
        {
            // Arrange
            var req = new CreateAdjusterRequest
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john@example.com",
                Phone = "555-555-5555"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/v1/adjuster", req);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task UpdateAdjuster_ReturnsOk()
        {
            //Arrange
            var req = new UpdateAdjusterRequest
            {
                FirstName = "Johnny",
                LastName = "Doeey",
                Email = "johnnny@gmail.com",
                Phone = "222-222-2222"
            };

            //Act
            var response = await _client.PutAsJsonAsync($"/api/v1/adjuster/7", req);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}

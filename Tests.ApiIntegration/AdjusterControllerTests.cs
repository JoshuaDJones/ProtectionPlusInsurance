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

        //[Fact]
        //public async Task GetAdjusterById_WhenExists_ReturnsOkAndDto()
        //{
        //    // First create a new adjuster
        //    var createReq = new CreateAdjusterRequest
        //    {
        //        FirstName = "Alice",
        //        LastName = "Smith",
        //        Email = "alice@example.com",
        //        Phone = "444-444-4444"
        //    };

        //    var createResponse = await _client.PostAsJsonAsync("/api/v1/adjuster", createReq);
        //    int id = await createResponse.Content.ReadFromJsonAsync<int>();

        //    // Act
        //    var response = await _client.GetAsync($"/api/v1/adjuster/{id}");

        //    // Assert
        //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        //    var dto = await response.Content.ReadFromJsonAsync<AdjusterDto>();
        //    Assert.Equal("Alice", dto.FirstName);
        //    Assert.Equal("Smith", dto.LastName);
        //}

        //[Fact]
        //public async Task GetAdjusterById_WhenNotExists_ReturnsOkWithNull()
        //{
        //    // Act
        //    var response = await _client.GetAsync("/api/v1/adjuster/99999999");

        //    // Assert
        //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        //    var dto = await response.Content.ReadFromJsonAsync<AdjusterDto>();
        //    Assert.Null(dto);
        //}

        //// -------------------
        ////  GET LIST TESTS
        //// -------------------

        //[Fact]
        //public async Task GetAdjustersList_ReturnsOkAndList()
        //{
        //    // Act
        //    var response = await _client.GetAsync("/api/v1/adjuster?pageNumber=1&pageSize=10");

        //    // Assert
        //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        //    var list = await response.Content.ReadFromJsonAsync<List<AdjusterDto>>();
        //    Assert.NotNull(list);
        //}

        //// -------------------
        ////  UPDATE TESTS
        //// -------------------

        //[Fact]
        //public async Task UpdateAdjuster_WhenExists_ReturnsOk_AndUpdatesRow()
        //{
        //    // First create a new adjuster
        //    var createReq = new CreateAdjusterRequest
        //    {
        //        FirstName = "Bob",
        //        LastName = "Marley",
        //        Email = "bob@example.com",
        //        Phone = "111-111-1111"
        //    };

        //    var createResponse = await _client.PostAsJsonAsync("/api/v1/adjuster", createReq);
        //    int id = await createResponse.Content.ReadFromJsonAsync<int>();

        //    // Update request
        //    var updateReq = new UpdateAdjusterRequest
        //    {
        //        FirstName = "Bobby",
        //        LastName = "Marley Jr",
        //        Email = "bobby@example.com",
        //        Phone = "222-222-2222"
        //    };

        //    // Act
        //    var updateResponse = await _client.PutAsJsonAsync($"/api/v1/adjuster/{id}", updateReq);

        //    // Assert
        //    Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);

        //    // Fetch updated item
        //    var getResponse = await _client.GetAsync($"/api/v1/adjuster/{id}");
        //    var dto = await getResponse.Content.ReadFromJsonAsync<AdjusterDto>();

        //    Assert.Equal("Bobby", dto.FirstName);
        //    Assert.Equal("Marley Jr", dto.LastName);
        //    Assert.Equal("bobby@example.com", dto.Email);
        //    Assert.Equal("222-222-2222", dto.Phone);
        //}

        //[Fact]
        //public async Task UpdateAdjuster_WhenNotExists_ReturnsBadRequest()
        //{
        //    var updateReq = new UpdateAdjusterRequest
        //    {
        //        FirstName = "Ghost",
        //        LastName = "Person",
        //        Email = "ghost@example.com",
        //        Phone = "000-000-0000"
        //    };

        //    var response = await _client.PutAsJsonAsync("/api/v1/adjuster/99999999", updateReq);

        //    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        //}

        //// -------------------
        ////  DELETE TESTS
        //// -------------------

        //[Fact]
        //public async Task DeleteAdjuster_WhenExists_ReturnsOk()
        //{
        //    // Create a new adjuster
        //    var createReq = new CreateAdjusterRequest
        //    {
        //        FirstName = "Delete",
        //        LastName = "Me",
        //        Email = "delete@example.com",
        //        Phone = "777-777-7777"
        //    };

        //    var createResponse = await _client.PostAsJsonAsync("/api/v1/adjuster", createReq);
        //    int id = await createResponse.Content.ReadFromJsonAsync<int>();

        //    // Act
        //    var deleteResponse = await _client.DeleteAsync($"/api/v1/adjuster/{id}");

        //    // Assert
        //    Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);

        //    // Verify it's really gone
        //    var getResponse = await _client.GetAsync($"/api/v1/adjuster/{id}");
        //    var dto = await getResponse.Content.ReadFromJsonAsync<AdjusterDto>();
        //    Assert.Null(dto);
        //}

        //[Fact]
        //public async Task DeleteAdjuster_WhenNotExists_ReturnsBadRequest()
        //{
        //    // Act
        //    var response = await _client.DeleteAsync("/api/v1/adjuster/99999999");

        //    // Assert
        //    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        //}
    }
}

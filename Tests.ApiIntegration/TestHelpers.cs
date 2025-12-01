using Api.ProtectionPlusInsurance.Requests.Adjuster;
using Api.ProtectionPlusInsurance.Requests.Claim;
using Api.ProtectionPlusInsurance.Requests.ClaimAdjuster;
using Api.ProtectionPlusInsurance.Requests.ClaimPayment;
using Api.ProtectionPlusInsurance.Requests.ClaimStatus;
using Api.ProtectionPlusInsurance.Requests.Incident;
using Api.ProtectionPlusInsurance.Requests.IncidentType;
using Api.ProtectionPlusInsurance.Requests.Policy;
using Api.ProtectionPlusInsurance.Requests.PolicyHolder;
using Api.ProtectionPlusInsurance.Requests.PolicyStatus;
using Api.ProtectionPlusInsurance.Requests.Property;
using Api.ProtectionPlusInsurance.Requests.PropertyType;
using System.Net;
using System.Net.Http.Json;

namespace Tests.ProtectionPlusInsurance
{
    public static class TestHelpers
    {        
        public static async Task<int> CreateAdjuster_Test(HttpClient client)
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
            var response = await client.PostAsJsonAsync("/api/v1/adjuster", req);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            int id = await response.Content.ReadFromJsonAsync<int>();
            Assert.True(id > 0);

            return id;
        }
        
        public static async Task<int> CreateClaimStatus_Test(HttpClient client)
        {
            // Arrange
            var request = new CreateClaimStatusRequest
            {
                StatusName = Guid.NewGuid().ToString("N"),
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/v1/claimstatus", request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            int id = await response.Content.ReadFromJsonAsync<int>();
            Assert.True(id > 0);

            return id;
        }

        public static async Task<int> CreateIncidentType_Test(HttpClient client)
        {
            // Arrange
            var request = new CreateIncidentTypeRequest
            {
                IncidentName = Guid.NewGuid().ToString("N"),
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/v1/incidenttype", request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            int id = await response.Content.ReadFromJsonAsync<int>();
            Assert.True(id > 0);

            return id;
        }

        public static async Task<int> CreatePolicyHolder_Test(HttpClient client)
        {
            // Arrange
            var request = new CreatePolicyHolderRequest
            {
                FirstName = "John",
                LastName = "Jones",
                Email = "test@gmail.com",
                Phone = "555-555-5555"
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/v1/policyholder", request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            int id = await response.Content.ReadFromJsonAsync<int>();
            Assert.True(id > 0);

            return id;
        }

        public static async Task<int> CreatePropertyType_Test(HttpClient client)
        {
            // Arrange
            var request = new CreatePropertyTypeRequest
            {
                TypeName = Guid.NewGuid().ToString("N"),
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/v1/propertytype", request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            int id = await response.Content.ReadFromJsonAsync<int>();
            Assert.True(id > 0);

            return id;
        }

        public static async Task<int> CreatePolicyStatus_Test(HttpClient client, int policyHolderId)
        {
            // Arrange
            var request = new CreatePolicyStatusRequest
            {
                StatusName = Guid.NewGuid().ToString("N"),
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/v1/PolicyStatus", request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            int id = await response.Content.ReadFromJsonAsync<int>();
            Assert.True(id > 0);

            return id;
        }

        public static async Task<int> CreateProperty_Test(HttpClient client, int policyHolderId, int propertyTypeId)
        {
            // Arrange
            var request = new CreatePropertyRequest
            {
                PolicyHolderId = policyHolderId,
                Address = "126 test test",
                City = "testcity",
                State = "TT",
                Zip = "18707",
                PropertyTypeId = propertyTypeId,
                YearBuilt = 1999
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/v1/property", request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            int id = await response.Content.ReadFromJsonAsync<int>();
            Assert.True(id > 0);

            return id;
        }

        public static async Task<int> CreateClaim_Test(HttpClient client, int incidentId, int claimStatusId)
        {
            // Arrange
            var request = new CreateClaimRequest
            {
                IncidentId = incidentId,
                ClaimStatusId = claimStatusId,
                ClaimNumber = Guid.NewGuid().ToString("N"),
                EstimatedLossAmount = null,
                ApprovedPayoutAmount = null
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/v1/claim", request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            int id = await response.Content.ReadFromJsonAsync<int>();
            Assert.True(id > 0);

            return id;
        }

        public static async Task<int> CreateClaimAdjuster_Test(HttpClient client, int claimId, int adjusterId)
        {
            // Arrange
            var request = new CreateClaimAdjusterRequest
            {
                ClaimId = claimId,
                AdjusterId = adjusterId,
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/v1/claimadjuster", request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            int id = await response.Content.ReadFromJsonAsync<int>();
            Assert.True(id > 0);

            return id;
        }

        public static async Task<int> CreateClaimPayment_Test(HttpClient client, int claimId, int claimPaymentMethodId)
        {
            // Arrange
            var request = new CreateClaimPaymentRequest
            {
                ClaimId = claimId,
                ClaimPaymentMethodId = claimPaymentMethodId,
                Amount = 123,
                PaymentDate = DateTime.UtcNow,
                ReferenceNumber = null
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/v1/claimpayment", request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            int id = await response.Content.ReadFromJsonAsync<int>();
            Assert.True(id > 0);

            return id;
        }

        public static async Task<int> CreateIncident_Test(HttpClient client, int policyId, int incidentTypeId)
        {
            // Arrange
            var request = new CreateIncidentRequest
            {
                PolicyId = policyId,
                IncidentTypeId = incidentTypeId,
                DateOfIncident = DateTime.UtcNow.AddDays(-10),
                Description = "There was a incident that was a test.",
                ReportedDate = DateTime.UtcNow,
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/v1/incident", request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            int id = await response.Content.ReadFromJsonAsync<int>();
            Assert.True(id > 0);

            return id;
        }

        public static async Task<int> CreatePolicy_Test(HttpClient client, int policyHolderId, int policyStatusId, int propertyId)
        {
            // Arrange
            var request = new CreatePolicyRequest
            {
                PolicyHolderId = policyHolderId,
                PolicyStatusId = policyStatusId,
                PropertyId = propertyId,
                PolicyNumber = Guid.NewGuid().ToString("N"),
                CoverageAmount = 2000,
                Deductible = 4150,
                EffectiveDate = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow,
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/v1/policy", request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            int id = await response.Content.ReadFromJsonAsync<int>();
            Assert.True(id > 0);

            return id;
        }
    }
}

using Application.ProtectionPlusInsurance.Common;
using Application.ProtectionPlusInsurance.Dtos;

namespace Application.ProtectionPlusInsurance.Services.Interfaces
{
    public interface IPropertyService
    {
        Task<Result<List<PropertyDto>>> GetPropertiesAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default);

        Task<Result<PropertyDto?>> GetPropertyByIdAsync(int propertyId,  CancellationToken ct = default);

        Task<Result<int>> CreatePropertyAsync(int policyHolderId, string address, string city, string state, string zip, 
            int propertyTypeId, int? yearBuilt, CancellationToken ct = default);

        Task<Result> UpdatePropertyAsync(int propertyId, int policyHolderId, string address, string city, string state, 
            string zip, int propertyTypeId, int? yearBuilt, CancellationToken ct = default);

        Task<Result> DeletePropertyAsync(int propertyId, CancellationToken ct = default);
    }
}

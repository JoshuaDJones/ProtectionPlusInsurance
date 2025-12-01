using Application.ProtectionPlusInsurance.Common;
using Application.ProtectionPlusInsurance.Dtos;

namespace Application.ProtectionPlusInsurance.Services.Interfaces
{
    public interface IPropertyTypeService
    {
        Task<Result<int>> CreatePropertyTypeAsync(string typeName, CancellationToken ct = default);
        Task<Result> DeletePropertyTypeAsync(int propertyTypeId, CancellationToken ct = default);
        Task<Result<PropertyTypeDto?>> GetPropertyTypeByIdAsync(int propertyTypeId, CancellationToken ct = default);
        Task<Result<List<PropertyTypeDto>>> GetPropertyTypesAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default);
        Task<Result> UpdatePropertyTypeAsync(int propertyTypeId, string typeName, CancellationToken ct = default);
    }
}

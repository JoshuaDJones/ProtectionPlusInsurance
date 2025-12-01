using Application.ProtectionPlusInsurance.Common;
using Application.ProtectionPlusInsurance.Dtos;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Core.ProtectionPlusInsurance.Entities;
using Core.ProtectionPlusInsurance.Interfaces;

namespace Application.ProtectionPlusInsurance.Services.Implementations
{
    public class PropertyTypeService : IPropertyTypeService
    {
        private readonly IPropertyTypeRepository _propertyTypeRepository;

        public PropertyTypeService(IPropertyTypeRepository propertyTypeRepository)
        {
            _propertyTypeRepository = propertyTypeRepository;
        }

        public async Task<Result<int>> CreatePropertyTypeAsync(string typeName, CancellationToken ct = default)
        {
            var propertyTypeId = await _propertyTypeRepository.CreateAsync(new PropertyType
            {
                TypeName = typeName
            }, ct);

            return Result<int>.Ok(propertyTypeId);
        }

        public async Task<Result> DeletePropertyTypeAsync(int propertyTypeId, CancellationToken ct = default)
        {
            var affectedRows = await _propertyTypeRepository.DeleteAsync(propertyTypeId, ct);

            if (affectedRows == 0)
                return Result.Fail(new Error("PropertyType.NotFound", "Property type does not exist."));

            return Result.Ok();
        }

        public async Task<Result<PropertyTypeDto?>> GetPropertyTypeByIdAsync(int propertyTypeId, CancellationToken ct = default)
        {
            var propertyType = await _propertyTypeRepository.GetByIdAsync(propertyTypeId, ct);

            if (propertyType == null)
                return Result<PropertyTypeDto?>.Ok(null);

            return Result<PropertyTypeDto?>.Ok(propertyType.ToDto());
        }

        public async Task<Result<List<PropertyTypeDto>>> GetPropertyTypesAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
        {
            var propertyTypes = await _propertyTypeRepository.GetListAsync(pageNumber, pageSize, ct);
            var propertyTypeDtos = propertyTypes.Select(p => p.ToDto()).ToList();

            return Result<List<PropertyTypeDto>>.Ok(propertyTypeDtos);
        }

        public async Task<Result> UpdatePropertyTypeAsync(int propertyTypeId, string typeName, CancellationToken ct = default)
        {
            var propertyType = new PropertyType
            {
                PropertyTypeId = propertyTypeId,
                TypeName = typeName
            };

            var affectedRows = await _propertyTypeRepository.UpdateAsync(propertyType, ct);

            if (affectedRows == 0)
                return Result.Fail(new Error("PropertyType.NotFound", "Property type does not exist."));

            return Result.Ok();
        }
    }
}

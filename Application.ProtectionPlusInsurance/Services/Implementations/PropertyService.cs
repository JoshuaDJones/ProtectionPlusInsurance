using Application.ProtectionPlusInsurance.Common;
using Application.ProtectionPlusInsurance.Dtos;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Core.ProtectionPlusInsurance.Entities;
using Core.ProtectionPlusInsurance.Interfaces;

namespace Application.ProtectionPlusInsurance.Services.Implementations
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IPolicyHolderRepository _policyHolderRepository;
        private readonly IPropertyTypeRepository _propertyTypeRepository;

        public PropertyService(IPropertyRepository propertyRepository, IPolicyHolderRepository policyHolderRepository, IPropertyTypeRepository propertyTypeRepository)
        {
            _propertyRepository = propertyRepository;
            _policyHolderRepository = policyHolderRepository;
            _propertyTypeRepository = propertyTypeRepository;
        }

        public async Task<Result<int>> CreatePropertyAsync(int policyHolderId, string address, 
            string city, string state, string zip, int propertyTypeId, int? yearBuilt, 
            CancellationToken ct = default)
        {
            var policyHolder = await _policyHolderRepository.GetByIdAsync(policyHolderId, ct);

            if (policyHolder is null)
                return Result<int>.Fail(new Error("PolicyHolder.NotFound", "Policy holder does not exist."));

            var propertyType = await _propertyTypeRepository.GetByIdAsync(propertyTypeId, ct);

            if (propertyType is null)
                return Result<int>.Fail(new Error("PropertyType.NotFound", "Property type does not exist."));

            var property = new Property
            {
                PolicyHolderId = policyHolderId,
                Address = address,
                City = city,
                State = state,
                Zip = zip,
                PropertyTypeId = propertyTypeId,
                YearBuilt = yearBuilt,
            };

            var propertyId = await _propertyRepository.CreateAsync(property, ct);

            return Result<int>.Ok(propertyId);
        }

        public async Task<Result> DeletePropertyAsync(int propertyId, CancellationToken ct = default)
        {
            var affectedRows = await _propertyRepository.DeleteAsync(propertyId, ct);

            if (affectedRows == 0)
                return Result.Fail(new Error("Property.NotFound", "Property does not exist."));

            return Result.Ok();
        }

        public async Task<Result<List<PropertyDto>>> GetPropertiesAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
        {
            var properties = await _propertyRepository.GetListAsync(pageNumber, pageSize, ct);
            var propertyDtos = properties.Select(p => p.ToDto()).ToList();

            return Result<List<PropertyDto>>.Ok(propertyDtos);
        }

        public async Task<Result<PropertyDto?>> GetPropertyByIdAsync(int propertyId, CancellationToken ct = default)
        {
            var property = await _propertyRepository.GetByIdAsync(propertyId, ct);

            if (property is null)
                return Result<PropertyDto?>.Fail(new Error("Property.NotFound", "Property does not exist."));

            return Result<PropertyDto?>.Ok(property.ToDto());
        }

        public async Task<Result> UpdatePropertyAsync(int propertyId, int policyHolderId, string address, string city, string state, string zip, int propertyTypeId, int? yearBuilt, CancellationToken ct = default)
        {
            var policyHolder = await _policyHolderRepository.GetByIdAsync(policyHolderId, ct);

            if (policyHolder is null)
                return Result.Fail(new Error("PolicyHolder.NotFound", "Policy holder does not exist."));

            var propertyType = await _propertyTypeRepository.GetByIdAsync(propertyTypeId, ct);

            if (propertyType is null)
                return Result.Fail(new Error("PropertyType.NotFound", "Property type does not exist."));

            var property = new Property
            {
                PropertyId = propertyId,
                PolicyHolderId = policyHolderId,
                Address = address,
                City = city,
                State = state,
                Zip = zip,
                PropertyTypeId = propertyTypeId,
                YearBuilt = yearBuilt,
            };

            var affectedRows = await _propertyRepository.UpdateAsync(property, ct);

            if (affectedRows == 0)
                return Result.Fail(new Error("Property.NotFound", "Property does not exist."));

            return Result.Ok();
        }
    }
}

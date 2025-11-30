using Application.ProtectionPlusInsurance.Dtos;

namespace Core.ProtectionPlusInsurance.Entities
{
    public static class PropertyMappings
    {
        public static PropertyDto ToDto(this Property property)
        {
            return new PropertyDto
            {
                PropertyId = property.PropertyId,
                PolicyHolderId = property.PolicyHolderId,
                Address = property.Address,
                City = property.City,
                State = property.State,
                Zip = property.Zip,
                PropertyTypeId = property.PropertyTypeId,
                YearBuilt = property.YearBuilt,
            };
        }
    }
}

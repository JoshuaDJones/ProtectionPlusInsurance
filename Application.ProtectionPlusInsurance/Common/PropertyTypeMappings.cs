using Application.ProtectionPlusInsurance.Dtos;

namespace Core.ProtectionPlusInsurance.Entities
{
    public static class PropertyTypeMappings
    {
        public static PropertyTypeDto ToDto(this PropertyType propertyType)
        {
            return new PropertyTypeDto
            {
                PropertyTypeId = propertyType.PropertyTypeId,
                TypeName = propertyType.TypeName
            };
        }
    }
}

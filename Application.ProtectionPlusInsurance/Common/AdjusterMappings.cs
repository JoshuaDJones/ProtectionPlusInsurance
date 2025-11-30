using Application.ProtectionPlusInsurance.Dtos;

namespace Core.ProtectionPlusInsurance.Entities
{
    public static class AdjusterMappings
    {
        public static AdjusterDto ToDto(this Adjuster adjuster)
        {
            return new AdjusterDto
            {
                AdjusterId = adjuster.AdjusterId,
                FirstName = adjuster.FirstName,
                LastName = adjuster.LastName,
                Email = adjuster.Email,
                Phone = adjuster.Phone
            };
        }
    }
}

using Application.ProtectionPlusInsurance.Dtos;

namespace Core.ProtectionPlusInsurance.Entities
{
    public static class ClaimAdjusterMappings
    {
        public static ClaimAdjusterDto ToDto(this ClaimAdjuster claimAdjuster)
        {
            return new ClaimAdjusterDto
            {
                ClaimAdjusterId = claimAdjuster.ClaimAdjusterId,
                ClaimId = claimAdjuster.ClaimId,
                AdjusterId = claimAdjuster.ClaimId,
                AssignedDate = claimAdjuster.AssignedDate,
            };
        }
    }
}

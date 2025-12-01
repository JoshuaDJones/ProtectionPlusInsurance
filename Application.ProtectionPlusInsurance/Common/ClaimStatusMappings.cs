using Application.ProtectionPlusInsurance.Dtos;

namespace Core.ProtectionPlusInsurance.Entities
{
    public static class ClaimStatusMappings
    {
        public static ClaimStatusDto ToDto(this ClaimStatus claimStatus)
        {
            return new ClaimStatusDto
            {
                ClaimStatusId = claimStatus.ClaimStatusId,
                StatusName = claimStatus.Statusname,
            };
        }
    }
}

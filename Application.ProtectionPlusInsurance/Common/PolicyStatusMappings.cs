using Application.ProtectionPlusInsurance.Dtos;

namespace Core.ProtectionPlusInsurance.Entities
{
    public static class PolicyStatusMappings
    {
        public static PolicyStatusDto ToDto(this PolicyStatus policyStatus)
        {
            return new PolicyStatusDto
            {
                PolicyStatusId = policyStatus.PolicyStatusId,
                StatusName = policyStatus.StatusName,
            };
        }
    }
}

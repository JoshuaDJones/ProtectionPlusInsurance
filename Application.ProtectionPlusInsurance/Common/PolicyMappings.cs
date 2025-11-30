using Application.ProtectionPlusInsurance.Dtos;

namespace Core.ProtectionPlusInsurance.Entities
{
    public static class PolicyMappings
    {
        public static PolicyDto ToDto(this Policy policy)
        {
            return new PolicyDto
            {
                PolicyId = policy.PolicyId,
                PolicyHolderId = policy.PolicyHolderId,
                PolicyStatusId = policy.PolicyStatusId,
                PropertyId = policy.PropertyId,
                PolicyNumber = policy.PolicyNumber,
                CoverageAmount = policy.CoverageAmount,
                Deductible = policy.Deductible,
                EffectiveDate = policy.EffectiveDate,
                ExpirationDate = policy.ExpirationDate,
            };
        }
    }
}

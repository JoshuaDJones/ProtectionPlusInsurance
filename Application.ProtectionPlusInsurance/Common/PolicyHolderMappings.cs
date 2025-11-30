using Application.ProtectionPlusInsurance.Dtos;

namespace Core.ProtectionPlusInsurance.Entities
{
    public static class PolicyHolderMappings
    {
        public static PolicyHolderDto ToDto(this PolicyHolder policyHolder)
        {
            return new PolicyHolderDto
            {
                PolicyHolderId = policyHolder.PolicyHolderId,
                FirstName = policyHolder.FirstName,
                LastName = policyHolder.LastName,
                Email = policyHolder.Email,
                Phone = policyHolder.Phone,
                CreatedDate = policyHolder.CreatedDate,
            };
        }
    }
}

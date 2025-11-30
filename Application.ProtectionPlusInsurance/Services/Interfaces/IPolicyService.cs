using Application.ProtectionPlusInsurance.Common;
using Application.ProtectionPlusInsurance.Dtos;

namespace Application.ProtectionPlusInsurance.Services.Interfaces
{
    public interface IPolicyService
    {
        Task<Result<List<PolicyDto>>> GetPoliciesAsync(int pageNumber = 1, int pageSize = 10, 
            CancellationToken ct = default);
        Task<Result<PolicyDto?>> GetPolicyByIdAsync(int policyId, CancellationToken ct = default);
        Task<Result> CreatePolicyAsync(int policyHolderId, int policyStatusId, 
            int propertyId, string policyNumber, decimal coverageAmount, 
            decimal deductible, DateTime effectiveDate, DateTime expirationDate, 
            CancellationToken ct = default);
        Task<Result> UpdatePolicyAsync(int policyId, int policyHolderId, int policyStatusId,
            int propertyId, string policyNumber, decimal coverageAmount,
            decimal deductible, DateTime effectiveDate, DateTime expirationDate,
            CancellationToken ct = default);
        Task<Result> DeletePolicyAsync(int policyId, CancellationToken ct = default);
    }
}

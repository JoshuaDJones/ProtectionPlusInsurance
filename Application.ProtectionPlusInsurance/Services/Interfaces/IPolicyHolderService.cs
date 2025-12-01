using Application.ProtectionPlusInsurance.Common;
using Application.ProtectionPlusInsurance.Dtos;

namespace Application.ProtectionPlusInsurance.Services.Interfaces
{
    public interface IPolicyHolderService
    {
        Task<Result<List<PolicyHolderDto>>> GetPolicyHoldersAsync(int pageNumber, int pageSize, 
            CancellationToken ct = default);

        Task<Result<PolicyHolderDto?>> GetPolicyHolderAsync(int policyHolderId, CancellationToken ct = default);

        Task<Result<int>> CreatePolicyHolderAsync(string firstName, string lastName, string email, 
            string phone, CancellationToken ct = default);

        Task<Result> UpdatePolicyHolderAsync(int policyHolderId, string firstName, string lastName, 
            string email, string phone, CancellationToken ct = default);

        Task<Result> DeletePolicyHolderAsync(int policyHolderId, CancellationToken ct = default);
    }
}

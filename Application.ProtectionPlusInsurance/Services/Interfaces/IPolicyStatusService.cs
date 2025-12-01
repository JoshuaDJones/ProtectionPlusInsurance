using Application.ProtectionPlusInsurance.Common;
using Application.ProtectionPlusInsurance.Dtos;

namespace Application.ProtectionPlusInsurance.Services.Interfaces
{
    public interface IPolicyStatusService
    {
        Task<Result<int>> CreatePolicyStatusAsync(string statusName, CancellationToken ct = default);
        Task<Result> DeletePolicyStatusAsync(int policyStatusId, CancellationToken ct = default);
        Task<Result<PolicyStatusDto?>> GetPolicyStatusByIdAsync(int policyStatusId, CancellationToken ct = default);
        Task<Result<List<PolicyStatusDto>>> GetPolicyStatusesAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default);
        Task<Result> UpdatePolicyStatusAsync(int policyStatusId, string statusName, CancellationToken ct = default);
    }
}

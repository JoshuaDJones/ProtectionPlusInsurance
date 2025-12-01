using Application.ProtectionPlusInsurance.Common;
using Application.ProtectionPlusInsurance.Dtos;

namespace Application.ProtectionPlusInsurance.Services.Interfaces
{
    public interface IClaimStatusService
    {
        Task<Result<int>> CreateClaimStatusAsync(string statusName, CancellationToken ct = default);
        Task<Result> DeleteClaimStatusAsync(int claimStatusId, CancellationToken ct = default);
        Task<Result<ClaimStatusDto?>> GetClaimStatusByIdAsync(int claimStatusId, CancellationToken ct = default);
        Task<Result<List<ClaimStatusDto>>> GetClaimStatusesAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default);
        Task<Result> UpdateClaimStatusAsync(int claimStatusId, string statusName, CancellationToken ct = default);
    }
}

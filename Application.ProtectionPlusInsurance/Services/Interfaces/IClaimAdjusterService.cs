using Application.ProtectionPlusInsurance.Common;
using Application.ProtectionPlusInsurance.Dtos;

namespace Application.ProtectionPlusInsurance.Services.Interfaces
{
    public interface IClaimAdjusterService
    {
        Task<Result<List<ClaimAdjusterDto>>> GetClaimAdjustersAsync(int pageNumber = 1, int pageSize = 10, 
            CancellationToken ct = default);

        Task<Result<ClaimAdjusterDto?>> GetClaimAdjusterAsync(int claimAdjusterId, 
            CancellationToken ct = default);

        Task<Result<int>> CreateClaimAdjusterAsync(int claimId, int adjusterId, DateTime assignedDate, 
            CancellationToken ct = default);

        Task<Result> UpdateClaimAdjusterAsync(int claimAdjusterId, int claimId, int adjusterId, 
            DateTime assignedDate, CancellationToken ct = default);

        Task<Result> DeleteClaimAdjusterAsync(int claimAdjusterId, CancellationToken ct = default);
    }
}

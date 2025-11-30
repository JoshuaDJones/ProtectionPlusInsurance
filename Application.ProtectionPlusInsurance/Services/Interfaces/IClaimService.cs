using Application.ProtectionPlusInsurance.Common;
using Core.ProtectionPlusInsurance.Entities;

namespace Application.ProtectionPlusInsurance.Services.Interfaces
{
    public interface IClaimService
    {
        Task<Result<List<ClaimDto>>> GetClaimsAsync(int pageNumber = 1, int pageSize = 10, 
            CancellationToken ct = default);

        Task<Result<ClaimDto?>> GetClaimByIdAsync(int claimId, CancellationToken ct = default);

        Task<Result> CreateClaimAsync(int incidentId, int claimStatusId, string claimNumber, 
            decimal? estimatedLossAmount, decimal? approvedPayoutAmount, CancellationToken ct = default);

        Task<Result> UpdateClaimAsync(int claimId, int incidentId, int claimStatusId, string claimNumber,
            decimal? estimatedLossAmount, decimal? approvedPayoutAmount, DateTime createdDate,
            DateTime lastUpdated, CancellationToken ct = default);

        Task<Result> DeleteClaimAsync(int claimId, CancellationToken ct = default);
    }
}

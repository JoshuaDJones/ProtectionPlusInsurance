using Application.ProtectionPlusInsurance.Common;
using Application.ProtectionPlusInsurance.Dtos;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Core.ProtectionPlusInsurance.Entities;
using Core.ProtectionPlusInsurance.Interfaces;

namespace Application.ProtectionPlusInsurance.Services.Implementations
{
    public class ClaimAdjusterService : IClaimAdjusterService
    {
        private readonly IClaimAdjusterRepository _claimAdjusterRepository;
        private readonly IAdjusterRepository _adjusterRepository;
        private readonly IClaimRepository _claimRepository;

        public ClaimAdjusterService(IClaimAdjusterRepository claimAdjusterRepository, IAdjusterRepository adjusterRepository, IClaimRepository claimRepository)
        {
            _claimAdjusterRepository = claimAdjusterRepository;
            _adjusterRepository = adjusterRepository;
            _claimRepository = claimRepository;
        }

        public async Task<Result<int>> CreateClaimAdjusterAsync(int claimId, int adjusterId, CancellationToken ct = default)
        {
            var adjuster = await _adjusterRepository.GetByIdAsync(adjusterId, ct);

            if (adjuster is null)
                return Result<int>.Fail(new Error("Adjuster.NotFound", "Adjuster does not exist"));

            var claim = await _claimRepository.GetByIdAsync(claimId, ct);

            if (claim is null)
                return Result<int>.Fail(new Error("Claim.NotFound", "Claim does not exist"));

            var claimAdjuster = new ClaimAdjuster
            {
                ClaimId = claimId,
                AdjusterId = adjusterId,
            };

            var claimAdjusterId = await _claimAdjusterRepository.CreateAsync(claimAdjuster, ct);

            return Result<int>.Ok(claimAdjusterId);
        }

        public async Task<Result> DeleteClaimAdjusterAsync(int claimAdjusterId, CancellationToken ct = default)
        {
            var affectedRows = await _claimAdjusterRepository.DeleteAsync(claimAdjusterId, ct);

            if (affectedRows == 0)
                return Result.Fail(new Error("ClaimAdjuster.NotFound", "Claim adjuster does not exist."));

            return Result.Ok();
        }

        public async Task<Result<ClaimAdjusterDto?>> GetClaimAdjusterAsync(int claimAdjusterId, CancellationToken ct = default)
        {
            var claimAdjuster = await _claimAdjusterRepository.GetByIdAsync(claimAdjusterId, ct);

            if (claimAdjuster is null)
                return Result<ClaimAdjusterDto?>.Ok(null);

            return Result<ClaimAdjusterDto?>.Ok(claimAdjuster.ToDto());
        }

        public async Task<Result<List<ClaimAdjusterDto>>> GetClaimAdjustersAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
        {
            var claimAdjusters = await _claimAdjusterRepository.GetListAsync(pageNumber, pageSize, ct);
            var claimAdjusterDtos = claimAdjusters.Select(c => c.ToDto()).ToList();

            return Result<List<ClaimAdjusterDto>>.Ok(claimAdjusterDtos);
        }

        public async Task<Result> UpdateClaimAdjusterAsync(int claimAdjusterId, int claimId, int adjusterId, CancellationToken ct = default)
        {
            var adjuster = await _adjusterRepository.GetByIdAsync(adjusterId, ct);

            if (adjuster is null)
                return Result.Fail(new Error("Adjuster.NotFound", "Adjuster does not exist"));

            var claim = await _claimRepository.GetByIdAsync(claimId, ct);

            if (claim is null)
                return Result.Fail(new Error("Claim.NotFound", "Claim does not exist"));

            var claimAdjuster = new ClaimAdjuster
            {
                ClaimAdjusterId = claimAdjusterId,
                ClaimId = claimId,
                AdjusterId = adjusterId,
            };

            var affectedRows = await _claimAdjusterRepository.UpdateAsync(claimAdjuster, ct);

            if (affectedRows == 0)
                return Result.Fail(new Error("ClaimAdjuster.NotFound", "Claim adjuster does not exist."));

            return Result.Ok();
        }
    }
}

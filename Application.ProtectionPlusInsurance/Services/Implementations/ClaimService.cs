using Application.ProtectionPlusInsurance.Common;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Core.ProtectionPlusInsurance.Entities;
using Core.ProtectionPlusInsurance.Interfaces;

namespace Application.ProtectionPlusInsurance.Services.Implementations
{
    public class ClaimService : IClaimService
    {
        private readonly IIncidentRepository _incidentRepository;
        private readonly IClaimStatusRepository _claimStatusRepository;
        private readonly IClaimRepository _claimRepository;

        public ClaimService(IIncidentRepository incidentRepository, IClaimStatusRepository claimStatusRepository, IClaimRepository claimRepository)
        {
            _incidentRepository = incidentRepository;
            _claimStatusRepository = claimStatusRepository;
            _claimRepository = claimRepository;
        }

        public async Task<Result<int>> CreateClaimAsync(int incidentId, int claimStatusId, string claimNumber, decimal? estimatedLossAmount, decimal? approvedPayoutAmount, CancellationToken ct = default)
        {
            var incident = await _incidentRepository.GetByIdAsync(incidentId, ct);

            if (incident is null)
                return Result<int>.Fail(new Error("Incident.NotFound", "Incident does not exist."));

            var claimStatus = await _claimStatusRepository.GetByIdAsync(claimStatusId, ct);

            if (claimStatus is null)
                return Result<int>.Fail(new Error("ClaimStatus.NotFound", "Claim status does not exist."));

            var claim = new Claim
            {
                IncidentId = incidentId,
                ClaimStatusId = claimStatusId,
                ClaimNumber = claimNumber,
                EstimatedLossAmount = estimatedLossAmount,
                ApprovedPayoutAmount = approvedPayoutAmount
            };

            var claimId = await _claimRepository.CreateAsync(claim, ct);

            return Result<int>.Ok(claimId);
        }

        public async Task<Result> DeleteClaimAsync(int claimId, CancellationToken ct = default)
        {
            var affectedRows = await _claimRepository.DeleteAsync(claimId, ct);

            if (affectedRows == 0)
                return Result.Fail(new Error("Claim.NotFound", "Claim does not exist."));

            return Result.Ok();
        }

        public async Task<Result<ClaimDto?>> GetClaimByIdAsync(int claimId, CancellationToken ct = default)
        {
            var claim = await _claimRepository.GetByIdAsync(claimId, ct);

            if (claim is null)
                return Result<ClaimDto?>.Fail(new Error("Claim.NotFound", "Claim does not exist."));

            return Result<ClaimDto?>.Ok(claim.ToDto());
        }

        public async Task<Result<List<ClaimDto>>> GetClaimsAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
        {
            var claims = await _claimRepository.GetListAsync(pageNumber, pageSize, ct);
            var claimDtos = claims.Select(c => c.ToDto()).ToList();

            return Result<List<ClaimDto>>.Ok(claimDtos);
        }

        public async Task<Result> UpdateClaimAsync(int claimId, int incidentId, int claimStatusId, string claimNumber, decimal? estimatedLossAmount, decimal? approvedPayoutAmount, DateTime createdDate, DateTime lastUpdated, CancellationToken ct = default)
        {
            var incident = await _incidentRepository.GetByIdAsync(incidentId, ct);

            if (incident is null)
                return Result.Fail(new Error("Incident.NotFound", "Incident does not exist."));

            var claimStatus = await _claimStatusRepository.GetByIdAsync(claimStatusId, ct);

            if (claimStatus is null)
                return Result.Fail(new Error("ClaimStatus.NotFound", "Claim status does not exist."));

            var claim = new Claim
            {
                ClaimId = claimId,
                IncidentId = incidentId,
                ClaimStatusId = claimStatusId,
                ClaimNumber = claimNumber,
                EstimatedLossAmount = estimatedLossAmount,
                ApprovedPayoutAmount = approvedPayoutAmount
            };

            var affectedRows = await _claimRepository.UpdateAsync(claim, ct);

            if (affectedRows == 0)
                return Result.Fail(new Error("Claim.NotFound", "Claim does not exist."));

            return Result.Ok();
        }
    }
}

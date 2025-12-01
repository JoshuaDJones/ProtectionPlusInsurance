using Application.ProtectionPlusInsurance.Common;
using Application.ProtectionPlusInsurance.Dtos;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Core.ProtectionPlusInsurance.Entities;
using Core.ProtectionPlusInsurance.Interfaces;

namespace Application.ProtectionPlusInsurance.Services.Implementations
{
    public class ClaimStatusService : IClaimStatusService
    {
        private readonly IClaimStatusRepository _claimStatusRepository;

        public ClaimStatusService(IClaimStatusRepository claimStatusRepository)
        {
            _claimStatusRepository = claimStatusRepository;
        }

        public async Task<Result<int>> CreateClaimStatusAsync(string statusName, CancellationToken ct = default)
        {
            var claimStatusId = await _claimStatusRepository.CreateAsync(new ClaimStatus
            {
                Statusname = statusName
            }, ct);

            return Result<int>.Ok(claimStatusId);
        }

        public async Task<Result> DeleteClaimStatusAsync(int claimStatusId, CancellationToken ct = default)
        {
            var affectedRows = await _claimStatusRepository.DeleteAsync(claimStatusId, ct);

            if (affectedRows == 0)
                return Result.Fail(new Error("ClaimStatus.NotFound", "Claim status does not exist."));

            return Result.Ok();
        }

        public async Task<Result<ClaimStatusDto?>> GetClaimStatusByIdAsync(int claimStatusId, CancellationToken ct = default)
        {
            var claimStatus = await _claimStatusRepository.GetByIdAsync(claimStatusId, ct);

            if (claimStatus == null)
                return Result<ClaimStatusDto?>.Ok(null);

            return Result<ClaimStatusDto?>.Ok(claimStatus.ToDto());
        }

        public async Task<Result<List<ClaimStatusDto>>> GetClaimStatusesAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
        {
            var claimStatuses = await _claimStatusRepository.GetListAsync(pageNumber, pageSize, ct);
            var claimStatusDtos = claimStatuses.Select(c => c.ToDto()).ToList();

            return Result<List<ClaimStatusDto>>.Ok(claimStatusDtos);
        }

        public async Task<Result> UpdateClaimStatusAsync(int claimStatusId, string statusName, CancellationToken ct = default)
        {
            var claimStatus = new ClaimStatus
            {
                ClaimStatusId = claimStatusId,
                Statusname = statusName
            };

            var affectedRows = await _claimStatusRepository.UpdateAsync(claimStatus, ct);

            if (affectedRows == 0)
                return Result.Fail(new Error("ClaimStatus.NotFound", "Claim status does not exist."));

            return Result.Ok();
        }
    }
}

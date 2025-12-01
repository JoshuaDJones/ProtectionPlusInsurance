using Application.ProtectionPlusInsurance.Common;
using Application.ProtectionPlusInsurance.Dtos;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Core.ProtectionPlusInsurance.Entities;
using Core.ProtectionPlusInsurance.Interfaces;

namespace Application.ProtectionPlusInsurance.Services.Implementations
{
    public class PolicyStatusService : IPolicyStatusService
    {
        private readonly IPolicyStatusRepository _policyStatusRepository;

        public PolicyStatusService(IPolicyStatusRepository policyStatusRepository)
        {
            _policyStatusRepository = policyStatusRepository;
        }

        public async Task<Result<int>> CreatePolicyStatusAsync(string statusName, CancellationToken ct = default)
        {
            var policyStatusId = await _policyStatusRepository.CreateAsync(new PolicyStatus
            {
                StatusName = statusName
            }, ct);

            return Result<int>.Ok(policyStatusId);
        }

        public async Task<Result> DeletePolicyStatusAsync(int policyStatusId, CancellationToken ct = default)
        {
            var affectedRows = await _policyStatusRepository.DeleteAsync(policyStatusId, ct);

            if (affectedRows == 0)
                return Result.Fail(new Error("PolicyStatus.NotFound", "Policy status does not exist."));

            return Result.Ok();
        }

        public async Task<Result<PolicyStatusDto?>> GetPolicyStatusByIdAsync(int policyStatusId, CancellationToken ct = default)
        {
            var policyStatus = await _policyStatusRepository.GetByIdAsync(policyStatusId, ct);

            if (policyStatus == null)
                return Result<PolicyStatusDto?>.Ok(null);

            return Result<PolicyStatusDto?>.Ok(policyStatus.ToDto());
        }

        public async Task<Result<List<PolicyStatusDto>>> GetPolicyStatusesAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
        {
            var policyStatuses = await _policyStatusRepository.GetListAsync(pageNumber, pageSize, ct);
            var policyStatusDtos = policyStatuses.Select(p => p.ToDto()).ToList();

            return Result<List<PolicyStatusDto>>.Ok(policyStatusDtos);
        }

        public async Task<Result> UpdatePolicyStatusAsync(int policyStatusId, string statusName, CancellationToken ct = default)
        {
            var policyStatus = new PolicyStatus
            {
                PolicyStatusId = policyStatusId,
                StatusName = statusName
            };

            var affectedRows = await _policyStatusRepository.UpdateAsync(policyStatus, ct);

            if (affectedRows == 0)
                return Result.Fail(new Error("PolicyStatus.NotFound", "Policy status does not exist."));

            return Result.Ok();
        }
    }
}

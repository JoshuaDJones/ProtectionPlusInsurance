using Application.ProtectionPlusInsurance.Common;
using Application.ProtectionPlusInsurance.Dtos;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Core.ProtectionPlusInsurance.Entities;
using Core.ProtectionPlusInsurance.Interfaces;

namespace Application.ProtectionPlusInsurance.Services.Implementations
{
    public class PolicyHolderService : IPolicyHolderService
    {
        private readonly IPolicyHolderRepository _policyHolderRepository;

        public PolicyHolderService(IPolicyHolderRepository policyHolderRepository)
        {
            _policyHolderRepository = policyHolderRepository;
        }

        public async Task<Result<int>> CreatePolicyHolderAsync(string firstName, string lastName, string email, 
            string phone, CancellationToken ct = default)
        {
            var policyHolder = new PolicyHolder
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
            };

            var policyHolderId = await _policyHolderRepository.CreateAsync(policyHolder, ct);

            return Result<int>.Ok(policyHolderId);
        }

        public async Task<Result> DeletePolicyHolderAsync(int policyHolderId, CancellationToken ct = default)
        {
            var affectedRows = await _policyHolderRepository.DeleteAsync(policyHolderId, ct);

            if (affectedRows == 0)
                return Result.Fail(new Error("PolicyHolder.NotFound", "Policy holder does not exist."));

            return Result.Ok();
        }

        public async Task<Result<PolicyHolderDto?>> GetPolicyHolderAsync(int policyHolderId, CancellationToken ct = default)
        {
            var policyHolder = await _policyHolderRepository.GetByIdAsync(policyHolderId, ct);

            if (policyHolder is null)
                return Result<PolicyHolderDto?>.Fail(new Error("PolicyHolder.NotFound", "Policy holder does not exist."));

            return Result<PolicyHolderDto?>.Ok(policyHolder.ToDto());
        }

        public async Task<Result<List<PolicyHolderDto>>> GetPolicyHoldersAsync(int pageNumber, int pageSize, CancellationToken ct = default)
        {
            var policyHolders = await _policyHolderRepository.GetListAsync(pageNumber, pageSize, ct);
            var policyHolderDtos = policyHolders.Select(p => p.ToDto()).ToList();   

            return Result<List<PolicyHolderDto>>.Ok(policyHolderDtos);
        }

        public async Task<Result> UpdatePolicyHolderAsync(int policyHolderId, string firstName, string lastName, string email, string phone, CancellationToken ct = default)
        {
            var policyHolder = new PolicyHolder
            {
                PolicyHolderId = policyHolderId,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
            };

            var affectedRows = await _policyHolderRepository.UpdateAsync(policyHolder, ct);

            if (affectedRows == 0)
                return Result.Fail(new Error("PolicyHolder.NotFound", "Policy holder does not exist."));

            return Result.Ok();
        }
    }
}

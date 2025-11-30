using Application.ProtectionPlusInsurance.Common;
using Application.ProtectionPlusInsurance.Dtos;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Core.ProtectionPlusInsurance.Entities;
using Core.ProtectionPlusInsurance.Interfaces;

namespace Application.ProtectionPlusInsurance.Services.Implementations
{
    public class PolicyService : IPolicyService
    {
        private readonly IPolicyHolderRepository _policyHolderRepository;
        private readonly IPolicyStatusRepository _policyStatusRepository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IPolicyRepository _policyRepository;

        public PolicyService(IPolicyHolderRepository policyHolderRepository, IPolicyStatusRepository policyStatusRepository,
            IPropertyRepository propertyRepository, IPolicyRepository policyRepository)
        {
            _policyHolderRepository = policyHolderRepository;
            _policyStatusRepository = policyStatusRepository;
            _propertyRepository = propertyRepository;
            _policyRepository = policyRepository;
        }

        public async Task<Result<int>> CreatePolicyAsync(int policyHolderId, int policyStatusId, int propertyId,
            string policyNumber, decimal coverageAmount, decimal deductible, DateTime effectiveDate,
            DateTime expirationDate, CancellationToken ct = default)
        {
            var policyHolder = await _policyHolderRepository.GetByIdAsync(policyHolderId, ct);

            if (policyHolder is null)
                return Result<int>.Fail(new Error("PolicyHolder.NotFound", "Policy holder does not exist."));

            var policyStatus = await _policyStatusRepository.GetByIdAsync(policyStatusId, ct);

            if (policyStatus is null)
                return Result<int>.Fail(new Error("PolicyStatus.NotFound", "Policy status does not exist."));

            var property = await _propertyRepository.GetByIdAsync(propertyId, ct);

            if (property is null)
                return Result<int>.Fail(new Error("Property.NotFound", "Property does not exist"));

            var policy = new Policy
            {
                PolicyHolderId = policyHolderId,
                PolicyStatusId = policyStatusId,
                PropertyId = propertyId,
                PolicyNumber = policyNumber,
                CoverageAmount = coverageAmount,
                Deductible = deductible,
                EffectiveDate = effectiveDate,
                ExpirationDate = expirationDate,
            };

            var policyId = await _policyRepository.CreateAsync(policy, ct);

            return Result<int>.Ok(policyId);
        }

        public async Task<Result> DeletePolicyAsync(int policyId, CancellationToken ct = default)
        {
            var affectedRows = await _policyRepository.DeleteAsync(policyId, ct);

            if (affectedRows == 0)
                return Result.Fail(new Error("Policy.NotFound", "Policy does not exist."));

            return Result.Ok();
        }

        public async Task<Result<List<PolicyDto>>> GetPoliciesAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
        {
            var policies = await _policyRepository.GetListAsync(pageNumber, pageSize, ct);
            var policyDtos = policies.Select(p => p.ToDto()).ToList();

            return Result<List<PolicyDto>>.Ok(policyDtos);
        }

        public async Task<Result<PolicyDto?>> GetPolicyByIdAsync(int policyId, CancellationToken ct = default)
        {
            var policy = await _policyRepository.GetByIdAsync(policyId, ct);

            if (policy is null)
                return Result<PolicyDto?>.Fail(new Error("Policy.NotFound", "Policy does not exist."));

            return Result<PolicyDto?>.Ok(policy.ToDto());
        }

        public async Task<Result> UpdatePolicyAsync(int policyId, int policyHolderId, int policyStatusId, int propertyId, string policyNumber, decimal coverageAmount, decimal deductible, DateTime effectiveDate, DateTime expirationDate, CancellationToken ct = default)
        {
            var policyHolder = await _policyHolderRepository.GetByIdAsync(policyHolderId, ct);

            if (policyHolder is null)
                return Result.Fail(new Error("PolicyHolder.NotFound", "Policy holder does not exist."));

            var policyStatus = await _policyStatusRepository.GetByIdAsync(policyStatusId, ct);

            if (policyStatus is null)
                return Result.Fail(new Error("PolicyStatus.NotFound", "Policy status does not exist."));

            var property = await _propertyRepository.GetByIdAsync(propertyId, ct);

            if (property is null)
                return Result.Fail(new Error("Property.NotFound", "Property does not exist"));

            var policy = new Policy
            {
                PolicyId = policyId,
                PolicyHolderId = policyHolderId,
                PolicyStatusId = policyStatusId,
                PropertyId = propertyId,
                PolicyNumber = policyNumber,
                CoverageAmount = coverageAmount,
                Deductible = deductible,
                EffectiveDate = effectiveDate,
                ExpirationDate = expirationDate,
            };

            var affectedRows = await _policyRepository.UpdateAsync(policy, ct);

            if (affectedRows == 0)
                return Result.Fail(new Error("Policy.NotFound", "Policy does not exist."));

            return Result.Ok();
        }
    }
}

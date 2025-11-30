using Application.ProtectionPlusInsurance.Common;
using Application.ProtectionPlusInsurance.Dtos;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Core.ProtectionPlusInsurance.Entities;
using Core.ProtectionPlusInsurance.Interfaces;

namespace Application.ProtectionPlusInsurance.Services.Implementations
{
    public class ClaimPaymentService : IClaimPaymentService
    {
        private readonly IClaimPaymentRepository _claimPaymentRepository;
        private readonly IClaimRepository _claimRepository;

        public ClaimPaymentService(IClaimPaymentRepository claimPaymentRepository, IClaimRepository claimRepository)
        {
            _claimPaymentRepository = claimPaymentRepository;
            _claimRepository = claimRepository;
        }

        public async Task<Result<int>> CreateClaimPaymentAsync(int claimId, int claimPaymentMethodId, 
            decimal amount, DateTime paymentDate, string? referenceNumber, CancellationToken ct = default)
        {
            var claim = await _claimRepository.GetByIdAsync(claimId, ct);

            if(claim is null)
                return Result<int>.Fail(new Error("Claim.NotFound", "Claim does not exist"));

            var claimPaymentMethod = await _claimPaymentRepository.GetByIdAsync(claimPaymentMethodId, ct);

            if (claimPaymentMethod is null)
                return Result<int>.Fail(new Error("ClaimPaymentMethod.NotFound", "Claim payment method does not exist."));

            var claimPayment = new ClaimPayment
            {
                ClaimId = claimId,
                ClaimPaymentMethodId = claimPaymentMethodId,
                Amount = amount,
                PaymentDate = paymentDate,
                ReferenceNumber = referenceNumber,
            };

            var claimPaymentId = await _claimPaymentRepository.CreateAsync(claimPayment, ct);

            return Result<int>.Ok(claimPaymentId);
        }

        public async Task<Result> DeleteClaimPaymentAsync(int claimPaymentId, CancellationToken ct = default)
        {
            var affectedRows = await _claimPaymentRepository.DeleteAsync(claimPaymentId, ct);

            if (affectedRows == 0)
                return Result.Fail(new Error("ClaimPayment.NotFound", "Claim payment does not exist."));

            return Result.Ok();
        }

        public async Task<Result<ClaimPaymentDto?>> GetClaimPaymentByIdAsync(int claimPaymentId, 
            CancellationToken ct = default)
        {
            var claimPayment = await _claimPaymentRepository.GetByIdAsync(claimPaymentId, ct);

            if (claimPayment is null)
                return Result<ClaimPaymentDto?>.Fail(new Error("ClaimPayment.NotFound", "Claim payment does not exist"));

            return Result<ClaimPaymentDto?>.Ok(claimPayment.ToDto());
        }

        public async Task<Result<List<ClaimPaymentDto>>> GetClaimPaymentsAsync(int pageNumber = 1, 
            int pageSize = 10, CancellationToken ct = default)
        {
            var claimPayments = await _claimPaymentRepository.GetListAsync(pageNumber, pageSize, ct);
            var claimPaymentDtos = claimPayments.Select(c => c.ToDto()).ToList();

            return Result<List<ClaimPaymentDto>>.Ok(claimPaymentDtos);
        }

        public async Task<Result> UpdateClaimPaymentAsync(int claimPaymentId, int claimId, int claimPaymentMethodId, 
            decimal amount, DateTime paymentDate, string? referenceNumber, CancellationToken ct = default)
        {
            var claim = await _claimRepository.GetByIdAsync(claimId, ct);

            if (claim is null)
                return Result.Fail(new Error("Claim.NotFound", "Claim does not exist"));

            var claimPaymentMethod = await _claimPaymentRepository.GetByIdAsync(claimPaymentMethodId, ct);

            if (claimPaymentMethod is null)
                return Result.Fail(new Error("ClaimPaymentMethod.NotFound", "Claim payment method does not exist."));

            var claimPayment = new ClaimPayment
            {
                ClaimPaymentId = claimPaymentId,
                ClaimId = claimId,
                ClaimPaymentMethodId = claimPaymentMethodId,
                Amount = amount,
                PaymentDate = paymentDate,
                ReferenceNumber = referenceNumber,
            };

            var affectedRows = await _claimPaymentRepository.UpdateAsync(claimPayment, ct);

            if (affectedRows == 0)
                return Result.Fail(new Error("ClaimPayment.NotFound", "Claim payment does not exist."));

            return Result.Ok();
        }
    }
}

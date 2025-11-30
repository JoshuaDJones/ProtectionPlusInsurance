using Application.ProtectionPlusInsurance.Common;
using Application.ProtectionPlusInsurance.Dtos;

namespace Application.ProtectionPlusInsurance.Services.Interfaces
{
    public interface IClaimPaymentService
    {
        Task<Result<List<ClaimPaymentDto>>> GetClaimPaymentsAsync(int pageNumber = 1,  int pageSize = 10, 
            CancellationToken ct = default);

        Task<Result<ClaimPaymentDto?>> GetClaimPaymentByIdAsync(int claimPaymentId, CancellationToken ct = default);

        Task<Result> CreateClaimPaymentAsync(int claimId, int claimPaymentMethodId, decimal amount, 
            DateTime paymentDate, string? referenceNumber, CancellationToken ct = default);

        Task<Result> UpdateClaimPaymentAsync(int claimPaymentId, int claimId, int claimPaymentMethodId, 
            decimal amount, DateTime paymentDate, string? referenceNumber, CancellationToken ct = default);

        Task<Result> DeleteClaimPaymentAsync(int claimPaymentId, CancellationToken ct = default);
    }
}

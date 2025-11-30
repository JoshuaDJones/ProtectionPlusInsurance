using Application.ProtectionPlusInsurance.Dtos;

namespace Core.ProtectionPlusInsurance.Entities
{
    public static class ClaimPaymentMappings
    {
        public static ClaimPaymentDto ToDto(this ClaimPayment claimPayment)
        {
            return new ClaimPaymentDto
            {
                ClaimPaymentId = claimPayment.ClaimPaymentId,
                ClaimId = claimPayment.ClaimId,
                ClaimPaymentMethodId = claimPayment.ClaimPaymentMethodId,
                Amount = claimPayment.Amount,
                PaymentDate = claimPayment.PaymentDate,
                ReferenceNumber = claimPayment.ReferenceNumber,
            };
         }
    }
}

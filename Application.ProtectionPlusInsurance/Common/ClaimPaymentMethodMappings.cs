using Application.ProtectionPlusInsurance.Dtos;

namespace Core.ProtectionPlusInsurance.Entities
{
    public static class ClaimPaymentMethodMappings
    {
        public static ClaimPaymentMethodDto ToDto(this ClaimPaymentMethod claimPaymentMethod)
        {
            return new ClaimPaymentMethodDto
            {
                ClaimPaymentMethodId = claimPaymentMethod.ClaimPaymentMethodId,
                PaymentMethodName = claimPaymentMethod.PaymentMethodName,
            };
        }
    }
}

namespace Core.ProtectionPlusInsurance.Entities
{
    public class ClaimPayment
    {
        public int ClaimPaymentId { get; set; }
        public int ClaimId { get; set; }
        public int ClaimPaymentMethodId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? ReferenceNumber { get; set; }
    }
}

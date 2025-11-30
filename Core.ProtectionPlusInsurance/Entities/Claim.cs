namespace Core.ProtectionPlusInsurance.Entities
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public int IncidentId { get; set; }
        public int ClaimStatusId { get; set; }
        public string ClaimNumber { get; set; } = string.Empty;
        public decimal? EstimatedLossAmount { get; set; }
        public decimal? ApprovedPayoutAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}

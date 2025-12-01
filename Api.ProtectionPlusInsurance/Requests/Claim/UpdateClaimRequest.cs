namespace Api.ProtectionPlusInsurance.Requests.Claim
{
    public class UpdateClaimRequest
    {
        public int IncidentId { get; set; }
        public int ClaimStatusId { get; set; }
        public string ClaimNumber { get; set; } = string.Empty;
        public decimal? EstimatedLossAmount { get; set; }
        public decimal? ApprovedPayoutAmount { get; set; }
    }
}

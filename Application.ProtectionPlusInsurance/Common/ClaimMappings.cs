namespace Core.ProtectionPlusInsurance.Entities
{
    public static class ClaimMappings
    {
        public static ClaimDto ToDto(this Claim claim)
        {
            return new ClaimDto
            {
                ClaimId = claim.ClaimId,
                IncidentId = claim.IncidentId,
                ClaimStatusId = claim.ClaimStatusId,
                ClaimNumber = claim.ClaimNumber,
                EstimatedLossAmount = claim.EstimatedLossAmount,
                ApprovedPayoutAmount = claim.ApprovedPayoutAmount,
                CreatedDate = claim.CreatedDate,
                LastUpdated = claim.LastUpdated,
            };
        }
    }
}

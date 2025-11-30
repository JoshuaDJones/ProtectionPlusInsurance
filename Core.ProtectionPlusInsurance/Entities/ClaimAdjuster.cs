namespace Core.ProtectionPlusInsurance.Entities
{
    public class ClaimAdjuster
    {
        public int ClaimAdjusterId { get; set; }
        public int ClaimId { get; set; }
        public int AdjusterId { get; set; }
        public DateTime AssignedDate { get; set; }
    }
}

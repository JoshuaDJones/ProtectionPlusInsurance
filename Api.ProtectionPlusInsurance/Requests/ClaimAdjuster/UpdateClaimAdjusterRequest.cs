using System.ComponentModel.DataAnnotations;

namespace Api.ProtectionPlusInsurance.Requests.ClaimAdjuster
{
    public class UpdateClaimAdjusterRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int ClaimId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int AdjusterId { get; set; }
    }
}

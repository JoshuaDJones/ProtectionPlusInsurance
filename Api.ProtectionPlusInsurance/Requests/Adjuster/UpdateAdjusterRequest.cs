using System.ComponentModel.DataAnnotations;

namespace Api.ProtectionPlusInsurance.Requests.Adjuster
{
    public class UpdateAdjusterRequest
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [Phone]
        public string Phone { get; set; } = string.Empty;
    }
}

using System.ComponentModel.DataAnnotations;

namespace Api.ProtectionPlusInsurance.Requests.Property
{
    public class UpdatePropertyRequest
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int PolicyHolderId { get; set; }

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string State { get; set; } = string.Empty;

        [Required]
        public string Zip { get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue)]
        public int PropertyTypeId { get; set; }

        public int? YearBuilt { get; set; }
    }
}

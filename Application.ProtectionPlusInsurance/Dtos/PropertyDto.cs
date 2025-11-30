namespace Application.ProtectionPlusInsurance.Dtos
{
    public class PropertyDto
    {
        public int PropertyId { get; set; }
        public int PolicyHolderId { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public int PropertyTypeId { get; set; }
        public int? YearBuilt { get; set; }
    }
}

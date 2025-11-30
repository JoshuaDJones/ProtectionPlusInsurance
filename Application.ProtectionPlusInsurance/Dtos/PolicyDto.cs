namespace Application.ProtectionPlusInsurance.Dtos
{
    public class PolicyDto
    {
        public int PolicyId { get; set; }
        public int PolicyHolderId { get; set; }
        public int PolicyStatusId { get; set; }
        public int PropertyId { get; set; }
        public string PolicyNumber { get; set; } = string.Empty;
        public decimal CoverageAmount { get; set; }
        public decimal Deductible { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}

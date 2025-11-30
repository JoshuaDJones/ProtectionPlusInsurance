namespace Core.ProtectionPlusInsurance.Entities
{
    public class Incident
    {
        public int IncidentId { get; set; }
        public int PolicyId { get; set; }
        public int IncidentTypeId { get; set; }
        public DateTime DateOfIncident { get; set; }
        public string? Description { get; set; }
        public DateTime ReportedDate { get; set; }
    }
}

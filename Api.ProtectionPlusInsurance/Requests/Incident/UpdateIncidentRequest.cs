namespace Api.ProtectionPlusInsurance.Requests.Incident
{
    public class UpdateIncidentRequest
    {
        public int PolicyId { get; set; }
        public int IncidentTypeId { get; set; }
        public DateTime DateOfIncident { get; set; }
        public string? Description { get; set; }
        public DateTime ReportedDate { get; set; }
    }
}

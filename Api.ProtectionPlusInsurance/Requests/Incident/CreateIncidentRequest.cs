namespace Api.ProtectionPlusInsurance.Requests.Incident
{
    public class CreateIncidentRequest
    {
        public int PolicyId { get; set; }
        public int IncidentTypeId { get; set; }
        public DateTime DateOfIncident { get; set; }
        public string? Description { get; set; }
        public DateTime ReportedDate { get; set; }
    }
}

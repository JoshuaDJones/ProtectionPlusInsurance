using Application.ProtectionPlusInsurance.Dtos;

namespace Core.ProtectionPlusInsurance.Entities
{
    public static class IncidentMappings
    {
        public static IncidentDto ToDto(this Incident incident)
        {
            return new IncidentDto
            {
                IncidentId = incident.IncidentId,
                PolicyId = incident.PolicyId,
                IncidentTypeId = incident.IncidentTypeId,
                DateOfIncident = incident.DateOfIncident,
                Description = incident.Description,
                ReportedDate = incident.ReportedDate,
            };
        }
    }
}

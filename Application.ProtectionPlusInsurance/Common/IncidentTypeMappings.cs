using Application.ProtectionPlusInsurance.Dtos;

namespace Core.ProtectionPlusInsurance.Entities
{
    public static class IncidentTypeMappings
    {
       public static IncidentTypeDto ToDto(this IncidentType incidentType)
        {
            return new IncidentTypeDto
            {
                IncidentTypeId = incidentType.IncidentTypeId,
                IncidentName = incidentType.IncidentName,
            };
        }
    }
}

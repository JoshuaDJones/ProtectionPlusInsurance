using Application.ProtectionPlusInsurance.Common;
using Application.ProtectionPlusInsurance.Dtos;

namespace Application.ProtectionPlusInsurance.Services.Interfaces
{
    public interface IIncidentService
    {
        Task<Result<List<IncidentDto>>> GetIncidentsAsync(int pageNumber = 1, int pageSize = 10, 
            CancellationToken ct = default);

        Task<Result<IncidentDto?>> GetIncidentByIdAsync(int incidentId, 
            CancellationToken ct = default);

        Task<Result<int>> CreateIncidentAsync(int policyId, int incidentTypeId, DateTime dateOfIncident, 
            string? description, DateTime ReportedDate, CancellationToken ct = default);

        Task<Result> UpdateIncidentAsync(int incidentId, int policyId, int incidentTypeId, 
            DateTime dateOfIncident, string? description, DateTime ReportedDate, 
            CancellationToken ct = default);

        Task<Result> DeleteIncidentAsync(int incidentId, CancellationToken ct = default);

    }
}

using Application.ProtectionPlusInsurance.Common;
using Application.ProtectionPlusInsurance.Dtos;

namespace Application.ProtectionPlusInsurance.Services.Interfaces
{
    public interface IIncidentTypeService
    {
        Task<Result<int>> CreateIncidentTypeAsync(string incidentName, CancellationToken ct = default);
        Task<Result> DeleteIncidentTypeAsync(int incidentTypeId, CancellationToken ct = default);
        Task<Result<IncidentTypeDto?>> GetIncidentTypeByIdAsync(int incidentTypeId, CancellationToken ct = default);
        Task<Result<List<IncidentTypeDto>>> GetIncidentTypesAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default);
        Task<Result> UpdateIncidentTypeAsync(int incidentTypeId, string incidentName, CancellationToken ct = default);
    }
}

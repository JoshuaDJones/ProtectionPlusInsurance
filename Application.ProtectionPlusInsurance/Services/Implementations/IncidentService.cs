using Application.ProtectionPlusInsurance.Common;
using Application.ProtectionPlusInsurance.Dtos;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Core.ProtectionPlusInsurance.Entities;
using Core.ProtectionPlusInsurance.Interfaces;

namespace Application.ProtectionPlusInsurance.Services.Implementations
{
    public class IncidentService : IIncidentService
    {
        private readonly IIncidentRepository _incidentRepository;        
        private readonly IPolicyRepository _policyRepository;
        private readonly IIncidentTypeRepository _incidentTypeRepository;

        public IncidentService(IIncidentRepository incidentRepository, IPolicyRepository policyRepository, IIncidentTypeRepository incidentTypeRepository)
        {
            _incidentRepository = incidentRepository;
            _policyRepository = policyRepository;
            _incidentTypeRepository = incidentTypeRepository;
        }

        public async Task<Result> CreateIncidentAsync(int policyId, int incidentTypeId, 
            DateTime dateOfIncident, string? description, DateTime ReportedDate, CancellationToken ct = default)
        {
            var policy = await _policyRepository.GetByIdAsync(policyId, ct);

            if (policy is null)
                return Result.Fail(new Error("Policy.NotFound", "Policy does not exist."));

            var incidentType = await _incidentTypeRepository.GetByIdAsync(incidentTypeId, ct);

            if (incidentType is null)
                return Result.Fail(new Error("Incident.NotFound", "Incident does not exist."));

            var incident = new Incident
            {
                PolicyId = policyId,
                IncidentTypeId = incidentTypeId,
                DateOfIncident = dateOfIncident,
                Description = description,
                ReportedDate = ReportedDate
            };

            await _incidentRepository.CreateAsync(incident, ct);

            return Result.Ok();
        }

        public async Task<Result> DeleteIncidentAsync(int incidentId, CancellationToken ct = default)
        {
            await _incidentRepository.DeleteAsync(incidentId, ct);

            return Result.Ok();
        }

        public async Task<Result<IncidentDto?>> GetIncidentByIdAsync(int incidentId, CancellationToken ct = default)
        {
            var incident = await _incidentRepository.GetByIdAsync(incidentId, ct);

            if (incident is null)
                return Result<IncidentDto?>.Fail(new Error("Incident.NotFound", "Incident does not exist."));

            return Result<IncidentDto?>.Ok(incident.ToDto());
        }

        public async Task<Result<List<IncidentDto>>> GetIncidentsAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
        {
            var incidents = await _incidentRepository.GetListAsync(pageNumber, pageSize, ct);
            var incidentDtos = incidents.Select(i => i.ToDto()).ToList();

            return Result<List<IncidentDto>>.Ok(incidentDtos);
        }

        public async Task<Result> UpdateIncidentAsync(int incidentId, int policyId, int incidentTypeId, DateTime dateOfIncident, string? description, DateTime ReportedDate, CancellationToken ct = default)
        {
            var policy = await _policyRepository.GetByIdAsync(policyId, ct);

            if (policy is null)
                return Result.Fail(new Error("Policy.NotFound", "Policy does not exist."));

            var incidentType = await _incidentTypeRepository.GetByIdAsync(incidentTypeId, ct);

            if (incidentType is null)
                return Result.Fail(new Error("Incident.NotFound", "Incident does not exist."));

            var incident = new Incident
            {
                IncidentId = incidentId,
                PolicyId = policyId,
                IncidentTypeId = incidentTypeId,
                DateOfIncident = dateOfIncident,
                Description = description,
                ReportedDate = ReportedDate
            };

            await _incidentRepository.UpdateAsync(incident, ct);

            return Result.Ok();
        }
    }
}

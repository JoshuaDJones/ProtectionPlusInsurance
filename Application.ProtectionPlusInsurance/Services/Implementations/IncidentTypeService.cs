using Application.ProtectionPlusInsurance.Common;
using Application.ProtectionPlusInsurance.Dtos;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Core.ProtectionPlusInsurance.Entities;
using Core.ProtectionPlusInsurance.Interfaces;

namespace Application.ProtectionPlusInsurance.Services.Implementations
{
    public class IncidentTypeService : IIncidentTypeService
    {
        private readonly IIncidentTypeRepository _incidentTypeRepository;

        public IncidentTypeService(IIncidentTypeRepository incidentTypeRepository)
        {
            _incidentTypeRepository = incidentTypeRepository;
        }

        public async Task<Result<int>> CreateIncidentTypeAsync(string incidentName, CancellationToken ct = default)
        {
            var incidentTypeId = await _incidentTypeRepository.CreateAsync(new IncidentType
            {
                IncidentName = incidentName
            }, ct);

            return Result<int>.Ok(incidentTypeId);
        }

        public async Task<Result> DeleteIncidentTypeAsync(int incidentTypeId, CancellationToken ct = default)
        {
            var affectedRows = await _incidentTypeRepository.DeleteAsync(incidentTypeId, ct);

            if (affectedRows == 0)
                return Result.Fail(new Error("IncidentType.NotFound", "Incident type does not exist."));

            return Result.Ok();
        }

        public async Task<Result<IncidentTypeDto?>> GetIncidentTypeByIdAsync(int incidentTypeId, CancellationToken ct = default)
        {
            var incidentType = await _incidentTypeRepository.GetByIdAsync(incidentTypeId, ct);

            if (incidentType == null)
                return Result<IncidentTypeDto?>.Ok(null);

            return Result<IncidentTypeDto?>.Ok(incidentType.ToDto());
        }

        public async Task<Result<List<IncidentTypeDto>>> GetIncidentTypesAsync(int pageNumber = 1, int pageSize = 10, CancellationToken ct = default)
        {
            var incidentTypes = await _incidentTypeRepository.GetListAsync(pageNumber, pageSize, ct);
            var incidentTypeDtos = incidentTypes.Select(i => i.ToDto()).ToList();

            return Result<List<IncidentTypeDto>>.Ok(incidentTypeDtos);
        }

        public async Task<Result> UpdateIncidentTypeAsync(int incidentTypeId, string incidentName, CancellationToken ct = default)
        {
            var incidentType = new IncidentType
            {
                IncidentTypeId = incidentTypeId,
                IncidentName = incidentName
            };

            var affectedRows = await _incidentTypeRepository.UpdateAsync(incidentType, ct);

            if (affectedRows == 0)
                return Result.Fail(new Error("IncidentType.NotFound", "Incident type does not exist."));

            return Result.Ok();
        }
    }
}

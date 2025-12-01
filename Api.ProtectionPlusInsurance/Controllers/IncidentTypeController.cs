using Api.ProtectionPlusInsurance.Requests.IncidentType;
using Application.ProtectionPlusInsurance.Dtos;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.ProtectionPlusInsurance.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IncidentTypeController : ControllerBase
    {
        private readonly IIncidentTypeService _incidentTypeService;

        public IncidentTypeController(IIncidentTypeService incidentTypeService)
        {
            _incidentTypeService = incidentTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<IncidentTypeDto>>> Get(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            CancellationToken ct = default)
        {
            var result = await _incidentTypeService.GetIncidentTypesAsync(pageNumber, pageSize, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpGet("{incidentTypeId:int}")]
        public async Task<ActionResult<IncidentTypeDto?>> Get(int incidentTypeId, CancellationToken ct = default)
        {
            var result = await _incidentTypeService.GetIncidentTypeByIdAsync(incidentTypeId, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateIncidentTypeRequest req,
            CancellationToken ct = default)
        {
            var result = await _incidentTypeService.CreateIncidentTypeAsync(
                req.IncidentName,
                ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpPut("{incidentTypeId:int}")]
        public async Task<IActionResult> Update(
            int incidentTypeId,
            [FromBody] UpdateIncidentTypeRequest req,
            CancellationToken ct = default)
        {
            var result = await _incidentTypeService.UpdateIncidentTypeAsync(
                incidentTypeId,
                req.IncidentName,
                ct);

            if (result.Success)
                return Ok();

            return BadRequest(result.Error);
        }

        [HttpDelete("{incidentTypeId:int}")]
        public async Task<IActionResult> Delete(int incidentTypeId, CancellationToken ct = default)
        {
            var result = await _incidentTypeService.DeleteIncidentTypeAsync(incidentTypeId, ct);

            if (result.Success)
                return Ok();

            return BadRequest(result.Error);
        }
    }
}

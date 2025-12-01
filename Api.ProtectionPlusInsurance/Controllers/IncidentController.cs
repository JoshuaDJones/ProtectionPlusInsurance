using Api.ProtectionPlusInsurance.Requests.Incident;
using Application.ProtectionPlusInsurance.Dtos;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.ProtectionPlusInsurance.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService _incidentService;

        public IncidentController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<IncidentDto>>> Get(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            CancellationToken ct = default)
        {
            var result = await _incidentService.GetIncidentsAsync(pageNumber, pageSize, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpGet("{incidentId:int}")]
        public async Task<ActionResult<IncidentDto?>> Get(int incidentId, CancellationToken ct = default)
        {
            var result = await _incidentService.GetIncidentByIdAsync(incidentId, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateIncidentRequest req, CancellationToken ct = default)
        {
            var result = await _incidentService.CreateIncidentAsync(
                req.PolicyId,
                req.IncidentTypeId,
                req.DateOfIncident,
                req.Description,
                req.ReportedDate,
                ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpPut("{incidentId:int}")]
        public async Task<IActionResult> Update(
            int incidentId,
            [FromBody] UpdateIncidentRequest req,
            CancellationToken ct = default)
        {
            var result = await _incidentService.UpdateIncidentAsync(
                incidentId,
                req.PolicyId,
                req.IncidentTypeId,
                req.DateOfIncident,
                req.Description,
                req.ReportedDate,
                ct);

            if (result.Success)
                return Ok();

            return BadRequest(result.Error);
        }

        [HttpDelete("{incidentId:int}")]
        public async Task<IActionResult> Delete(int incidentId, CancellationToken ct = default)
        {
            var result = await _incidentService.DeleteIncidentAsync(incidentId, ct);

            if (result.Success)
                return Ok();

            return BadRequest(result.Error);
        }
    }
}

using Api.ProtectionPlusInsurance.Requests.ClaimStatus;
using Application.ProtectionPlusInsurance.Dtos;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.ProtectionPlusInsurance.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClaimStatusController : ControllerBase
    {
        private readonly IClaimStatusService _claimStatusService;

        public ClaimStatusController(IClaimStatusService claimStatusService)
        {
            _claimStatusService = claimStatusService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClaimStatusDto>>> Get(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            CancellationToken ct = default)
        {
            var result = await _claimStatusService.GetClaimStatusesAsync(pageNumber, pageSize, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpGet("{claimStatusId:int}")]
        public async Task<ActionResult<ClaimStatusDto?>> Get(int claimStatusId, CancellationToken ct = default)
        {
            var result = await _claimStatusService.GetClaimStatusByIdAsync(claimStatusId, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateClaimStatusRequest req,
            CancellationToken ct = default)
        {
            var result = await _claimStatusService.CreateClaimStatusAsync(
                req.StatusName,
                ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpPut("{claimStatusId:int}")]
        public async Task<IActionResult> Update(
            int claimStatusId,
            [FromBody] UpdateClaimStatusRequest req,
            CancellationToken ct = default)
        {
            var result = await _claimStatusService.UpdateClaimStatusAsync(
                claimStatusId,
                req.StatusName,
                ct);

            if (result.Success)
                return Ok();

            return BadRequest(result.Error);
        }

        [HttpDelete("{claimStatusId:int}")]
        public async Task<IActionResult> Delete(int claimStatusId, CancellationToken ct = default)
        {
            var result = await _claimStatusService.DeleteClaimStatusAsync(claimStatusId, ct);

            if (result.Success)
                return Ok();

            return BadRequest(result.Error);
        }
    }
}

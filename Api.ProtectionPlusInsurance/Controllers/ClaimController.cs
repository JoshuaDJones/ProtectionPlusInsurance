using Api.ProtectionPlusInsurance.Requests.Claim;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Core.ProtectionPlusInsurance.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.ProtectionPlusInsurance.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly IClaimService _claimService;

        public ClaimController(IClaimService claimService)
        {
            _claimService = claimService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClaimDto>>> Get(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            CancellationToken ct = default)
        {
            var result = await _claimService.GetClaimsAsync(pageNumber, pageSize, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpGet("{claimId:int}")]
        public async Task<ActionResult<ClaimDto?>> Get(int claimId, CancellationToken ct = default)
        {
            var result = await _claimService.GetClaimByIdAsync(claimId, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClaimRequest req, CancellationToken ct = default)
        {
            var result = await _claimService.CreateClaimAsync(
                req.IncidentId,
                req.ClaimStatusId,
                req.ClaimNumber,
                req.EstimatedLossAmount,
                req.ApprovedPayoutAmount,
                ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpPut("{claimId:int}")]
        public async Task<IActionResult> Update(
            int claimId,
            [FromBody] UpdateClaimRequest req,
            CancellationToken ct = default)
        {
            var result = await _claimService.UpdateClaimAsync(
                claimId,
                req.IncidentId,
                req.ClaimStatusId,
                req.ClaimNumber,
                req.EstimatedLossAmount,
                req.ApprovedPayoutAmount,
                ct);

            if (result.Success)
                return Ok();

            return BadRequest(result.Error);
        }

        [HttpDelete("{claimId:int}")]
        public async Task<IActionResult> Delete(int claimId, CancellationToken ct = default)
        {
            var result = await _claimService.DeleteClaimAsync(claimId, ct);

            if (result.Success)
                return Ok();

            return BadRequest(result.Error);
        }
    }
}

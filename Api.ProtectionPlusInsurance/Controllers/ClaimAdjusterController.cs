using Api.ProtectionPlusInsurance.Requests.ClaimAdjuster;
using Application.ProtectionPlusInsurance.Dtos;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.ProtectionPlusInsurance.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClaimAdjusterController : ControllerBase
    {
        private readonly IClaimAdjusterService _claimAdjusterService;

        public ClaimAdjusterController(IClaimAdjusterService claimAdjusterService)
        {
            _claimAdjusterService = claimAdjusterService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClaimAdjusterDto>>> Get(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            CancellationToken ct = default)
        {
            var result = await _claimAdjusterService.GetClaimAdjustersAsync(pageNumber, pageSize, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpGet("{claimAdjusterId:int}")]
        public async Task<ActionResult<ClaimAdjusterDto?>> Get(int claimAdjusterId, CancellationToken ct = default)
        {
            var result = await _claimAdjusterService.GetClaimAdjusterAsync(claimAdjusterId, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClaimAdjusterRequest req, CancellationToken ct = default)
        {
            var result = await _claimAdjusterService.CreateClaimAdjusterAsync(
                req.ClaimId,
                req.AdjusterId,
                ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpPut("{claimAdjusterId:int}")]
        public async Task<IActionResult> Update(
            int claimAdjusterId,
            [FromBody] UpdateClaimAdjusterRequest req,
            CancellationToken ct = default)
        {
            var result = await _claimAdjusterService.UpdateClaimAdjusterAsync(
                claimAdjusterId,
                req.ClaimId,
                req.AdjusterId,
                ct);

            if (result.Success)
                return Ok();

            return BadRequest(result.Error);
        }

        [HttpDelete("{claimAdjusterId:int}")]
        public async Task<IActionResult> Delete(int claimAdjusterId, CancellationToken ct = default)
        {
            var result = await _claimAdjusterService.DeleteClaimAdjusterAsync(claimAdjusterId, ct);

            if (result.Success)
                return Ok();

            return BadRequest(result.Error);
        }
    }
}

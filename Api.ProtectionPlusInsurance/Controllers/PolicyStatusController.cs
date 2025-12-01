using Api.ProtectionPlusInsurance.Requests.PolicyStatus;
using Application.ProtectionPlusInsurance.Dtos;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.ProtectionPlusInsurance.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PolicyStatusController : ControllerBase
    {
        private readonly IPolicyStatusService _policyStatusService;

        public PolicyStatusController(IPolicyStatusService policyStatusService)
        {
            _policyStatusService = policyStatusService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PolicyStatusDto>>> Get(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            CancellationToken ct = default)
        {
            var result = await _policyStatusService.GetPolicyStatusesAsync(pageNumber, pageSize, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpGet("{policyStatusId:int}")]
        public async Task<ActionResult<PolicyStatusDto?>> Get(int policyStatusId, CancellationToken ct = default)
        {
            var result = await _policyStatusService.GetPolicyStatusByIdAsync(policyStatusId, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreatePolicyStatusRequest req,
            CancellationToken ct = default)
        {
            var result = await _policyStatusService.CreatePolicyStatusAsync(
                req.StatusName,
                ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpPut("{policyStatusId:int}")]
        public async Task<IActionResult> Update(
            int policyStatusId,
            [FromBody] UpdatePolicyStatusRequest req,
            CancellationToken ct = default)
        {
            var result = await _policyStatusService.UpdatePolicyStatusAsync(
                policyStatusId,
                req.StatusName,
                ct);

            if (result.Success)
                return Ok();

            return BadRequest(result.Error);
        }

        [HttpDelete("{policyStatusId:int}")]
        public async Task<IActionResult> Delete(int policyStatusId, CancellationToken ct = default)
        {
            var result = await _policyStatusService.DeletePolicyStatusAsync(policyStatusId, ct);

            if (result.Success)
                return Ok();

            return BadRequest(result.Error);
        }
    }
}

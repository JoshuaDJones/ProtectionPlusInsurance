using Api.ProtectionPlusInsurance.Requests.Policy;
using Application.ProtectionPlusInsurance.Dtos;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.ProtectionPlusInsurance.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyService _policyService;

        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PolicyDto>>> Get(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            CancellationToken ct = default)
        {
            var result = await _policyService.GetPoliciesAsync(pageNumber, pageSize, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpGet("{policyId:int}")]
        public async Task<ActionResult<PolicyDto?>> Get(int policyId, CancellationToken ct = default)
        {
            var result = await _policyService.GetPolicyByIdAsync(policyId, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreatePolicyRequest req,
            CancellationToken ct = default)
        {
            var result = await _policyService.CreatePolicyAsync(
                req.PolicyHolderId,
                req.PolicyStatusId,
                req.PropertyId,
                req.PolicyNumber,
                req.CoverageAmount,
                req.Deductible,
                req.EffectiveDate,
                req.ExpirationDate,
                ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpPut("{policyId:int}")]
        public async Task<IActionResult> Update(
            int policyId,
            [FromBody] UpdatePolicyRequest req,
            CancellationToken ct = default)
        {
            var result = await _policyService.UpdatePolicyAsync(
                policyId,
                req.PolicyHolderId,
                req.PolicyStatusId,
                req.PropertyId,
                req.PolicyNumber,
                req.CoverageAmount,
                req.Deductible,
                req.EffectiveDate,
                req.ExpirationDate,
                ct);

            if (result.Success)
                return Ok();

            return BadRequest(result.Error);
        }

        [HttpDelete("{policyId:int}")]
        public async Task<IActionResult> Delete(int policyId, CancellationToken ct = default)
        {
            var result = await _policyService.DeletePolicyAsync(policyId, ct);

            if (result.Success)
                return Ok();

            return BadRequest(result.Error);
        }
    }
}

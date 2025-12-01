using Api.ProtectionPlusInsurance.Requests.PolicyHolder;
using Application.ProtectionPlusInsurance.Dtos;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.ProtectionPlusInsurance.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PolicyHolderController : ControllerBase
    {
        private readonly IPolicyHolderService _policyHolderService;

        public PolicyHolderController(IPolicyHolderService policyHolderService)
        {
            _policyHolderService = policyHolderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PolicyHolderDto>>> Get(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            CancellationToken ct = default)
        {
            var result = await _policyHolderService.GetPolicyHoldersAsync(pageNumber, pageSize, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpGet("{policyHolderId:int}")]
        public async Task<ActionResult<PolicyHolderDto?>> Get(int policyHolderId, CancellationToken ct = default)
        {
            var result = await _policyHolderService.GetPolicyHolderAsync(policyHolderId, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreatePolicyHolderRequest req,
            CancellationToken ct = default)
        {
            var result = await _policyHolderService.CreatePolicyHolderAsync(
                req.FirstName,
                req.LastName,
                req.Email,
                req.Phone,
                ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpPut("{policyHolderId:int}")]
        public async Task<IActionResult> Update(
            int policyHolderId,
            [FromBody] UpdatePolicyHolderRequest req,
            CancellationToken ct = default)
        {
            var result = await _policyHolderService.UpdatePolicyHolderAsync(
                policyHolderId,
                req.FirstName,
                req.LastName,
                req.Email,
                req.Phone,
                ct);

            if (result.Success)
                return Ok();

            return BadRequest(result.Error);
        }

        [HttpDelete("{policyHolderId:int}")]
        public async Task<IActionResult> Delete(int policyHolderId, CancellationToken ct = default)
        {
            var result = await _policyHolderService.DeletePolicyHolderAsync(policyHolderId, ct);

            if (result.Success)
                return Ok();

            return BadRequest(result.Error);
        }
    }
}

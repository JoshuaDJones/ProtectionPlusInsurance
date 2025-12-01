using Api.ProtectionPlusInsurance.Requests.ClaimPayment;
using Application.ProtectionPlusInsurance.Dtos;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.ProtectionPlusInsurance.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClaimPaymentController : ControllerBase
    {
        private readonly IClaimPaymentService _claimPaymentService;

        public ClaimPaymentController(IClaimPaymentService claimPaymentService)
        {
            _claimPaymentService = claimPaymentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClaimPaymentDto>>> Get(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            CancellationToken ct = default)
        {
            var result = await _claimPaymentService.GetClaimPaymentsAsync(pageNumber, pageSize, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpGet("{claimPaymentId:int}")]
        public async Task<ActionResult<ClaimPaymentDto?>> Get(int claimPaymentId, CancellationToken ct = default)
        {
            var result = await _claimPaymentService.GetClaimPaymentByIdAsync(claimPaymentId, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClaimPaymentRequest req, CancellationToken ct = default)
        {
            var result = await _claimPaymentService.CreateClaimPaymentAsync(
                req.ClaimId,
                req.ClaimPaymentMethodId,
                req.Amount,
                req.PaymentDate,
                req.ReferenceNumber,
                ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpPut("{claimPaymentId:int}")]
        public async Task<IActionResult> Update(
            int claimPaymentId,
            [FromBody] UpdateClaimPaymentRequest req,
            CancellationToken ct = default)
        {
            var result = await _claimPaymentService.UpdateClaimPaymentAsync(
                claimPaymentId,
                req.ClaimId,
                req.ClaimPaymentMethodId,
                req.Amount,
                req.PaymentDate,
                req.ReferenceNumber,
                ct);

            if (result.Success)
                return Ok();

            return BadRequest(result.Error);
        }

        [HttpDelete("{claimPaymentId:int}")]
        public async Task<IActionResult> Delete(int claimPaymentId, CancellationToken ct = default)
        {
            var result = await _claimPaymentService.DeleteClaimPaymentAsync(claimPaymentId, ct);

            if (result.Success)
                return Ok();

            return BadRequest(result.Error);
        }
    }
}

using Api.ProtectionPlusInsurance.Requests.Adjuster;
using Application.ProtectionPlusInsurance.Dtos;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.ProtectionPlusInsurance.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AdjusterController : ControllerBase
    {
        private readonly IAdjusterService _adjusterService;

        public AdjusterController(IAdjusterService adjusterService)
        {
            _adjusterService = adjusterService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdjusterDto>>> Get([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, CancellationToken ct = default)
        {
            var result = await _adjusterService.GetAdjustersAsync(pageNumber, pageSize, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpGet("{adjusterId:int}")]
        public async Task<ActionResult<AdjusterDto>> Get(int adjusterId, CancellationToken ct = default)
        {
            var result = await _adjusterService.GetAdjusterByIdAsync(adjusterId, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAdjusterRequest req, CancellationToken ct = default)
        {
            var result = await _adjusterService.CreateAdjusterAsync(req.FirstName, req.LastName, req.Email, req.Phone, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpDelete("{adjusterId:int}")]
        public async Task<IActionResult> Delete(int adjusterId, CancellationToken ct = default)
        {
            var result = await _adjusterService.DeleteAdjusterAsync(adjusterId, ct);

            if(result.Success)
                return Ok();

            return BadRequest(result.Error);
        }

        [HttpPut("{adjusterId:int}")]
        public async Task<IActionResult> Update(int adjusterId, [FromBody] UpdateAdjusterRequest req, CancellationToken ct = default)
        {
            var result = await _adjusterService.UpdateAdjusterAsync(adjusterId, req.FirstName, req.LastName, req.Email, req.Phone, ct);

            if (result.Success)
                return Ok();

            return BadRequest(result.Error);
        }
    }
}

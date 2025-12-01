using Api.ProtectionPlusInsurance.Requests.Property;
using Application.ProtectionPlusInsurance.Dtos;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.ProtectionPlusInsurance.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PropertyDto>>> Get(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            CancellationToken ct = default)
        {
            var result = await _propertyService.GetPropertiesAsync(pageNumber, pageSize, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpGet("{propertyId:int}")]
        public async Task<ActionResult<PropertyDto?>> Get(
            int propertyId,
            CancellationToken ct = default)
        {
            var result = await _propertyService.GetPropertyByIdAsync(propertyId, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreatePropertyRequest req,
            CancellationToken ct = default)
        {
            var result = await _propertyService.CreatePropertyAsync(
                req.PolicyHolderId,
                req.Address,
                req.City,
                req.State,
                req.Zip,
                req.PropertyTypeId,
                req.YearBuilt,
                ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpPut("{propertyId:int}")]
        public async Task<IActionResult> Update(
            int propertyId,
            [FromBody] UpdatePropertyRequest req,
            CancellationToken ct = default)
        {
            var result = await _propertyService.UpdatePropertyAsync(
                propertyId,
                req.PolicyHolderId,
                req.Address,
                req.City,
                req.State,
                req.Zip,
                req.PropertyTypeId,
                req.YearBuilt,
                ct);

            if (result.Success)
                return Ok();

            return BadRequest(result.Error);
        }

        [HttpDelete("{propertyId:int}")]
        public async Task<IActionResult> Delete(
            int propertyId,
            CancellationToken ct = default)
        {
            var result = await _propertyService.DeletePropertyAsync(propertyId, ct);

            if (result.Success)
                return Ok();

            return BadRequest(result.Error);
        }
    }
}

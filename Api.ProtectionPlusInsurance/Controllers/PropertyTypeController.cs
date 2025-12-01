using Api.ProtectionPlusInsurance.Requests.PropertyType;
using Application.ProtectionPlusInsurance.Dtos;
using Application.ProtectionPlusInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.ProtectionPlusInsurance.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PropertyTypeController : ControllerBase
    {
        private readonly IPropertyTypeService _propertyTypeService;

        public PropertyTypeController(IPropertyTypeService propertyTypeService)
        {
            _propertyTypeService = propertyTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PropertyTypeDto>>> Get(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            CancellationToken ct = default)
        {
            var result = await _propertyTypeService.GetPropertyTypesAsync(pageNumber, pageSize, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpGet("{propertyTypeId:int}")]
        public async Task<ActionResult<PropertyTypeDto?>> Get(int propertyTypeId, CancellationToken ct = default)
        {
            var result = await _propertyTypeService.GetPropertyTypeByIdAsync(propertyTypeId, ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePropertyTypeRequest req, CancellationToken ct = default)
        {
            var result = await _propertyTypeService.CreatePropertyTypeAsync(
                req.TypeName,
                ct);

            if (result.Success)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }

        [HttpPut("{propertyTypeId:int}")]
        public async Task<IActionResult> Update(
            int propertyTypeId,
            [FromBody] UpdatePropertyTypeRequest req,
            CancellationToken ct = default)
        {
            var result = await _propertyTypeService.UpdatePropertyTypeAsync(
                propertyTypeId,
                req.TypeName,
                ct);

            if (result.Success)
                return Ok();

            return BadRequest(result.Error);
        }

        [HttpDelete("{propertyTypeId:int}")]
        public async Task<IActionResult> Delete(int propertyTypeId, CancellationToken ct = default)
        {
            var result = await _propertyTypeService.DeletePropertyTypeAsync(propertyTypeId, ct);

            if (result.Success)
                return Ok();

            return BadRequest(result.Error);
        }
    }
}

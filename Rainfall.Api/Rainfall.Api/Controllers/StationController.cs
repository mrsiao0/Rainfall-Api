using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rainfall.Api.Domain.FluentValidations;
using Rainfall.Api.Domain.Request;
using Rainfall.Api.Domain.Settings;

namespace Rainfall.Api.Controllers
{
    [Route("rainfall")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StationController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("id/{stationId}/readings")]
        public async Task<IActionResult> GetStationReadings(string stationId, [FromQuery] int count = 10)
        {
            var request = new StationsRequest
            {
                Count = count,
                StationId = stationId
            };
            var validator = new StationsRequestValidator();
            var validationResult = validator.Validate(request);
            if(!validationResult.IsValid)
                return BadRequest(new ApiErrorSetting
                {
                    Message = "Invalid Request"
                });

            var result = await _mediator.Send(request);
            if(result is null)
                return NoContent();

            return Ok(result);
        }
    }
}

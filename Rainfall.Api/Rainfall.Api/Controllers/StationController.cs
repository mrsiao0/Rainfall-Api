using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rainfall.Api.Domain.FluentValidations;
using Rainfall.Api.Domain.Request;
using Rainfall.Api.Domain.Settings;

namespace Rainfall.Api.Controllers
{
    [Route("rainfall")]
    [ApiController]
    [Produces("application/json")]
    public class StationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StationController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Operations relating to rainfall
        /// </summary>
        /// <response code="200">A list of rainfall readings successfully retrieved</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">No readings found for the specified stationId</response>
        /// <response code="500">Internal server error</response>
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

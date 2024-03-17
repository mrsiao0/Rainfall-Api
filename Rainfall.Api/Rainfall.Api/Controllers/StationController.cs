using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rainfall.Api.Domain.Request;
using Rainfall.Api.Domain.ViewModel;

namespace Rainfall.Api.Controllers
{
    [Route("api/station")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StationController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("list/{stationId}")]
        public async Task<StationsReading> GetStationReadings([FromQuery]int count, string stationId)
        {
            return await _mediator.Send(new StationsRequest
            {
                Count = count,
                StationId = stationId
            });
        }
    }
}

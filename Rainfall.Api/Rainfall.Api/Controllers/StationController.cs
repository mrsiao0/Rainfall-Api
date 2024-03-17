﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rainfall.Api.Domain.Request;
using Rainfall.Api.Domain.ViewModel;

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
        public async Task<IActionResult> GetStationReadings([FromQuery]int count, string stationId)
        {
            if (count == 5)
                return BadRequest();

            return Ok( await _mediator.Send(new StationsRequest
            {
                Count = count,
                StationId = stationId
            }));
        }
    }
}
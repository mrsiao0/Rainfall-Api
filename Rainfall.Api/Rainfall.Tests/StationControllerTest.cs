using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using Rainfall.Api.Controllers;
using Rainfall.Api.Domain.Request;
using Rainfall.Api.Domain.ViewModel;
using Rainfall.Tests.Mocks;

namespace Rainfall.Tests
{
    public class StationControllerTest
    {
        [Fact]
        public async Task Get_Readings_Success()
        {
            var mockMediatr = new Mock<IMediator>();
            var mockResult = MockStationServiceQuery.StationReadings;
            var request = new StationsRequest
            {
                StationId = "E7050",
                Count = 10
            };

            mockMediatr.Setup(m => m.Send(It.IsAny<StationsRequest>(), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(mockResult);

            var controller = new StationController(mockMediatr.Object);

            // Act
            var actionResult = await controller.GetStationReadings(request.StationId, request.Count);

            // Assert
            var okResult = actionResult as OkObjectResult;
            var mockResponse = okResult.Value as StationsReading;

            Assert.NotNull(mockResponse);
            Assert.True(mockResponse.Items.Count() <= request.Count);
        }


        [Fact]
        public async Task Invalid_Request_Count_Less_Than_0()
        {
            var mockMediatr = new Mock<IMediator>();
            var mockResult = MockStationServiceQuery.StationReadings;
            var request = new StationsRequest
            {
                StationId = "E7050",
                Count = -10
            };

            mockMediatr.Setup(m => m.Send(It.IsAny<StationsRequest>(), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(mockResult);

            var controller = new StationController(mockMediatr.Object);

            // Act
            var actionResult = await controller.GetStationReadings(request.StationId, request.Count);

            // Assert
            var response = actionResult as ObjectResult;

            Assert.Equal(400, (response.StatusCode));
        }

        [Fact]
        public async Task Invalid_Request_StationId_Request_Null()
        {
            var mockMediatr = new Mock<IMediator>();
            var mockResult = MockStationServiceQuery.StationReadings;
            var request = new StationsRequest
            {
                StationId = null,
                Count = -10
            };

            mockMediatr.Setup(m => m.Send(It.IsAny<StationsRequest>(), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(mockResult);

            var controller = new StationController(mockMediatr.Object);

            // Act
            var actionResult = await controller.GetStationReadings(request.StationId, request.Count);

            // Assert
            var response = actionResult as ObjectResult;

            Assert.Equal(400, (response.StatusCode));
        }

        [Fact]
        public async Task Invalid_Request_Count_More_Than_100()
        {
            var mockMediatr = new Mock<IMediator>();
            var mockResult = MockStationServiceQuery.StationReadings;
            var request = new StationsRequest
            {
                StationId = "E7050",
                Count = -10
            };

            mockMediatr.Setup(m => m.Send(It.IsAny<StationsRequest>(), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(mockResult);

            var controller = new StationController(mockMediatr.Object);

            // Act
            var actionResult = await controller.GetStationReadings(request.StationId, request.Count);

            // Assert
            var response = actionResult as ObjectResult;

            Assert.Equal(400, (response.StatusCode));
        }
    }
}
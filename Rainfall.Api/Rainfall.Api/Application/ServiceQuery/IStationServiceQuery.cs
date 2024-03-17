using Rainfall.Api.Domain.Request;
using Rainfall.Api.Domain.ViewModel;

namespace Rainfall.Api.Application.ServiceQuery
{
    public interface IStationServiceQuery
    {
        Task<StationsReading> StationInfos(StationsRequest request, CancellationToken cancellationToken);
    }
}
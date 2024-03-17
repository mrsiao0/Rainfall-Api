using Rainfall.Api.Domain.Request;
using Rainfall.Api.Domain.ViewModel;

namespace Rainfall.Api.Data.RepositoryQuery
{
    public interface IStationRepositoryQuery
    {
        Task<StationsReading> GetListStations(StationsRequest request, CancellationToken cancellationToken);
    }
}
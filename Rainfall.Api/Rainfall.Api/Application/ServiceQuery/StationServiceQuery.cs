using Rainfall.Api.Data.RepositoryQuery;
using Rainfall.Api.Domain.Request;
using Rainfall.Api.Domain.ViewModel;

namespace Rainfall.Api.Application.ServiceQuery
{
    public class StationServiceQuery : IStationServiceQuery
    {
        private readonly IStationRepositoryQuery _stationRepositoryQuery;
        public StationServiceQuery(IStationRepositoryQuery stationRepositoryQuery)
        {
            _stationRepositoryQuery = stationRepositoryQuery ?? throw new ArgumentNullException(nameof(stationRepositoryQuery));
        }
        public async Task<StationsReading> StationInfos(StationsRequest request, CancellationToken cancellationToken)
        {
            var readings = await _stationRepositoryQuery.GetListStations(request, cancellationToken);
            
            if(readings is not null)
                readings.Items = readings.Items.Take(request.Count);
            
            return readings;
        }
    }
}

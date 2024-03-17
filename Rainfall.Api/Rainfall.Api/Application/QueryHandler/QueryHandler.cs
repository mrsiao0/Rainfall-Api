using MediatR;
using Rainfall.Api.Application.ServiceQuery;
using Rainfall.Api.Domain.Request;
using Rainfall.Api.Domain.ViewModel;

namespace Rainfall.Api.Application.QueryHandler
{
    public class QueryHandler : IRequestHandler<StationsRequest, StationsReading>
    {
        private readonly IStationServiceQuery _stationServiceQuery;
        public QueryHandler(IStationServiceQuery stationServiceQuery)
        {
            _stationServiceQuery = stationServiceQuery ?? throw new ArgumentNullException(nameof(stationServiceQuery));
        }
        public async Task<StationsReading> Handle(StationsRequest request, CancellationToken cancellationToken)
        {
            return await _stationServiceQuery.StationInfos(request, cancellationToken);
        }
    }
}
 
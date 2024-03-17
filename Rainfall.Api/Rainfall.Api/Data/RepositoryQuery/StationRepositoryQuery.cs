using Microsoft.Extensions.Options;
using Rainfall.Api.Data.Helpers;
using Rainfall.Api.Domain.Request;
using Rainfall.Api.Domain.Settings;
using Rainfall.Api.Domain.ViewModel;
using System.Net;

namespace Rainfall.Api.Data.RepositoryQuery
{
    public class StationRepositoryQuery : IStationRepositoryQuery
    {
        private readonly IHttpHelpers _httpHelpers;
        private readonly IOptions<RainfallApiSetting> _rainfallApiSetting;
        public StationRepositoryQuery(IHttpHelpers httpHelpers, IOptions<RainfallApiSetting> rainfallApiSetting)
        {
            _httpHelpers = httpHelpers ?? throw new ArgumentNullException(nameof(httpHelpers));
            _rainfallApiSetting = rainfallApiSetting ?? throw new ArgumentNullException(nameof(rainfallApiSetting));
        }

        public async Task<StationsReading> GetListStations(StationsRequest request, CancellationToken cancellationToken)
        {
            var httpResponse = await _httpHelpers.HttpGetCallApi($"{_rainfallApiSetting.Value.BaseUrl}{string.Format(_rainfallApiSetting.Value.StationReadings, request.StationId)}");

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                return JsonHelper.DeserializeOrDefault<StationsReading>(await httpResponse.Content.ReadAsStringAsync());
            }

            throw new ApiErrorSetting 
            {
                Message = "Bad Request"
            };
        }
    }
}

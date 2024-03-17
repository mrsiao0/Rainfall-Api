using Rainfall.Api.Application.ServiceQuery;
using Rainfall.Api.Data.Helpers;
using Rainfall.Api.Data.RepositoryQuery;

namespace Rainfall.Api.Dependencies
{
    public static class LocalDependencies
    {
        public static void AddLocalDependencies(this IServiceCollection services)
        {
            services.AddScoped<IHttpHelpers, HttpHelpers>();
            services.AddScoped<IStationRepositoryQuery, StationRepositoryQuery>();
            services.AddScoped<IStationServiceQuery, StationServiceQuery>();
        }
    }
}

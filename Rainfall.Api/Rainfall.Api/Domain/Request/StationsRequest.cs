using MediatR;
using Rainfall.Api.Domain.ViewModel;

namespace Rainfall.Api.Domain.Request
{
    public class StationsRequest: IRequest<StationsReading>
    {
        public string StationId { get; set; }
        public int Count { get; set; }
    }
}


namespace Rainfall.Api.Data.Helpers
{
    public interface IHttpHelpers
    {
        Task<HttpResponseMessage> HttpGetCallApi(string endpoint, Dictionary<string, string> headers = null);
    }
}
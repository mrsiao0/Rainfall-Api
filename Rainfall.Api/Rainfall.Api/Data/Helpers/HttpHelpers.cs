using Rainfall.Api.Domain.Settings;

namespace Rainfall.Api.Data.Helpers
{
    public class HttpHelpers : IHttpHelpers
    {
        public async Task<HttpResponseMessage> HttpGetCallApi(string endpoint, Dictionary<string, string> headers = null)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();

                    if (headers is not null)
                        foreach (var header in headers)
                        {
                            client.DefaultRequestHeaders.Add(header.Key, headers.Values);
                        }

                    return await client.GetAsync(endpoint);

                }
            }
            catch (HttpRequestException ex)
            {
                //TODO: Logs
                return new HttpResponseMessage
                {
                    StatusCode = (ex.StatusCode.HasValue) ? ex.StatusCode.Value : System.Net.HttpStatusCode.InternalServerError,
                };
            }
            catch
            {
                //TODO: Logs
                return new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }
    }
}

using RegistryApi.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RegistryApi.Core.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public HttpResponseMessage PostSync(string path, string content, Dictionary<string, string>? headers = null)
        {
            try
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    Content = new StringContent(content, Encoding.UTF8, "application/json"),
                    RequestUri = new Uri(path),
                };

                foreach (var header in headers ?? new Dictionary<string, string>())
                {
                    request.Headers.Add(header.Key, header.Value);
                }

                return _httpClient.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

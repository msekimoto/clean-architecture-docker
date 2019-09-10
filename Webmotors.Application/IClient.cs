using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Webmotors.Application
{
    public sealed class IClient<TEntity>
    {
        private const string JsonMediaType = "application/json";
        private readonly string _addressSuffix;
        private HttpClient _httpClient;

        public IClient(string serviceBaseAddress, string addressSuffix)
        {
            _addressSuffix = addressSuffix;
            _httpClient = MakeHttpClient(serviceBaseAddress);
        }

        private HttpClient MakeHttpClient(string serviceBaseAddress)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(serviceBaseAddress), Timeout = TimeSpan.FromMilliseconds(30000) };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(JsonMediaType));
            return _httpClient;
        }

        public async Task<TEntity> Get()
        {
            var responseMessage = _httpClient.GetAsync(_addressSuffix);
            var result = await responseMessage.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TEntity>(result);
        }
    }
}
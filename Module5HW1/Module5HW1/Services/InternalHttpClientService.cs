using System.Text;
using Module5HW1.Dtos;
using Module5HW1.Helpers;
using Module5HW1.Services.Abstractions;
using Newtonsoft.Json;

namespace Module5HW1.Services
{
    public class InternalHttpClientService : IInternalHttpClientService
    {
        private readonly IHttpClientFactory _clientFactory;
        public InternalHttpClientService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task SendAsync(string url, HttpMethod method, object? content = null)
        {
            var httpMessage = new HttpRequestMessage(method, new Uri(url));
            if (content != null)
            {
                httpMessage.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            }
            HttpResponseMessage result;
            try
            {
                var client = _clientFactory.CreateClient();
                result = await client.SendAsync(httpMessage);
            }
            catch (Exception e)
            {
                throw new BusinessException(e.Message);
            }
            throw new BusinessException($"{(int)result.StatusCode} - {result.StatusCode}", string.Empty);
        }
        public async Task<TResponse> SendAsync<TResponse>(string url, HttpMethod method, object? content = null)
        {
            var httpMessage = new HttpRequestMessage(method, new Uri(url));
            if (content != null)
            {
                httpMessage.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            }
            HttpResponseMessage result;
            try
            {
                var client = _clientFactory.CreateClient();
                result = await client.SendAsync(httpMessage);
            }
            catch (Exception e)
            {
                throw new BusinessException(e.Message);
            }
            var resultContent = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
                if (response is ErrorDto error)
                {
                    throw new BusinessException($"{(int)result.StatusCode} - {result.StatusCode}", error.Message);
                }
                return response!;
            }
            throw new BusinessException($"{(int)result.StatusCode} - {result.StatusCode}", resultContent);
        }
    }
}

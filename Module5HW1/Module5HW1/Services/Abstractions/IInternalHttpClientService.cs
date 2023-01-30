namespace Module5HW1.Services.Abstractions
{
    public interface IInternalHttpClientService
    {
        Task SendAsync(string url, HttpMethod method, object? content = null);
        Task<TResponse> SendAsync<TResponse>(string url, HttpMethod method, object? content = null);
    }
}

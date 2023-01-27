namespace Module5HW1.Services.Abstractions
{
    public interface IInternalHttpClientService
    {
        Task<TResponse> SendAsync<TResponse>(string url, HttpMethod method, object? content = null);
    }
}

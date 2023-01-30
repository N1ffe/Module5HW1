using Microsoft.Extensions.Options;
using Module5HW1.Config;
using Module5HW1.Dtos;
using Module5HW1.Dtos.Responses;
using Module5HW1.Models;
using Module5HW1.Services.Abstractions;

namespace Module5HW1.Services
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        private readonly IInternalHttpClientService _internalHttpClientService;
        private readonly ApiOption _apiOption;
        public AuthenticationService(IInternalHttpClientService internalHttpClientService, IOptions<ApiOption> apiOption)
        {
            _internalHttpClientService = internalHttpClientService;
            _apiOption = apiOption.Value;
        }
        public async Task<RegisterResult> Register(string email, string password)
        {
            return await ExecuteSafeAsync(async () =>
            {
                AuthenticationDto request = new AuthenticationDto() { Email = email, Password = password };
                var response = await _internalHttpClientService.SendAsync<RegisterResponse>($"{_apiOption.Host}/register", HttpMethod.Post, request);
                if (response != null)
                {
                    return new RegisterResult()
                    {
                        Id = response.Id,
                        Token = response.Token
                    };
                }
                return null!;
            });
        }
        public async Task<LoginResult> Login(string email, string password)
        {
            return await ExecuteSafeAsync(async () =>
            {
                AuthenticationDto request = new AuthenticationDto() { Email = email, Password = password };
                var response = await _internalHttpClientService.SendAsync<LoginResponse>($"{_apiOption.Host}/login", HttpMethod.Post, request);
                if (response != null)
                {
                    return new LoginResult()
                    {
                        Token = response.Token
                    };
                }
                return null!;
            });
        }
    }
}

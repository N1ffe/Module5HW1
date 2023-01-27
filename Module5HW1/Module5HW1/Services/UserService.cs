using Microsoft.Extensions.Options;
using Module5HW1.Config;
using Module5HW1.Dtos;
using Module5HW1.Dtos.Responses;
using Module5HW1.Models;
using Module5HW1.Services.Abstractions;

namespace Module5HW1.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IInternalHttpClientService _internalHttpClientService;
        private readonly ApiOption _apiOption;
        public UserService(IInternalHttpClientService internalHttpClientService, IOptions<ApiOption> apiOption)
        {
            _internalHttpClientService = internalHttpClientService;
            _apiOption = apiOption.Value;
        }
        public async Task<User> GetUser(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var response = await _internalHttpClientService.SendAsync<PagingResponse<UserDto>>($"{_apiOption.Host}/users/{id}", HttpMethod.Get);
                if (response.Data != null)
                {
                    return new User
                    {
                        Id = response.Data.Id,
                        Email = response.Data.Email,
                        FirstName = response.Data.FirstName,
                        LastName = response.Data.LastName,
                        AvatarUrl = response.Data.AvatarUrl
                    };
                }
                return null!;
            });
        }
        public async Task<StatusCollection<User>> GetUsersByPage(int page)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var response = await _internalHttpClientService.SendAsync<PagingResponse<UserDto[]>>($"{_apiOption.Host}/users?page={page}", HttpMethod.Get);
                if (response.Data != null)
                {
                    return new StatusCollection<User>()
                    {
                        Data = response.Data.Select(u => new User
                        {
                            Id = u.Id,
                            Email = u.Email,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            AvatarUrl = u.AvatarUrl
                        }).ToList()
                    };
                }
                return null!;
            });
        }
        public async Task<StatusCollection<User>> GetUsersByPageWithDelay(int delay)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var response = await _internalHttpClientService.SendAsync<PagingResponse<UserDto[]>>($"{_apiOption.Host}/users?delay={delay}", HttpMethod.Get);
                if (response.Data != null)
                {
                    return new StatusCollection<User>()
                    {
                        Data = response.Data.Select(u => new User
                        {
                            Id = u.Id,
                            Email = u.Email,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            AvatarUrl = u.AvatarUrl
                        }).ToList()
                    };
                }
                return null!;
            });
        }
    }
}

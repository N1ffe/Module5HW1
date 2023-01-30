using Microsoft.Extensions.Options;
using Module5HW1.Config;
using Module5HW1.Dtos;
using Module5HW1.Models;
using Module5HW1.Services.Abstractions;

namespace Module5HW1.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IInternalHttpClientService _internalHttpClientService;
        private readonly ApiOption _apiOption;
        public EmployeeService(IInternalHttpClientService internalHttpClientService, IOptions<ApiOption> apiOption)
        {
            _internalHttpClientService = internalHttpClientService;
            _apiOption = apiOption.Value;
        }
        public async Task<Employee> CreateEmployee(string name, string job)
        {
            return await ExecuteSafeAsync(async () =>
            {
                EmployeeDto request = new EmployeeDto() { Name = name, Job = job };
                var response = await _internalHttpClientService.SendAsync<EmployeeDto>($"{_apiOption.Host}/users", HttpMethod.Post, request);
                if (response != null)
                {
                    return new Employee()
                    {
                        Id = response.Id,
                        Name = response.Name,
                        Job = response.Job,
                        CreatedAt = response.CreatedAt,
                        UpdatedAt = response.UpdatedAt
                    };
                }
                return null!;
            });
        }
        public async Task<Employee> UpdateEmployee(int id, string name, string job)
        {
            return await ExecuteSafeAsync(async () =>
            {
                EmployeeDto request = new EmployeeDto() { Name = name, Job = job };
                var response = await _internalHttpClientService.SendAsync<EmployeeDto>($"{_apiOption.Host}/users/{id}", HttpMethod.Put, request);
                if (response != null)
                {
                    return new Employee()
                    {
                        Id = response.Id,
                        Name = response.Name,
                        Job = response.Job,
                        CreatedAt = response.CreatedAt,
                        UpdatedAt = response.UpdatedAt
                    };
                }
                return null!;
            });
        }
        public async Task<Employee> ModifyEmployee(int id, string name, string job)
        {
            return await ExecuteSafeAsync(async () =>
            {
                EmployeeDto request = new EmployeeDto() { Name = name, Job = job };
                var response = await _internalHttpClientService.SendAsync<EmployeeDto>($"{_apiOption.Host}/users/{id}", HttpMethod.Patch, request);
                if (response != null)
                {
                    return new Employee()
                    {
                        Id = response.Id,
                        Name = response.Name,
                        Job = response.Job,
                        CreatedAt = response.CreatedAt,
                        UpdatedAt = response.UpdatedAt
                    };
                }
                return null!;
            });
        }
        public async Task<VoidResult> RemoveEmployee(int id)
        {
            return await ExecuteSafeAsync<VoidResult>(async () =>
            {
                await _internalHttpClientService.SendAsync($"{_apiOption.Host}/users/{id}", HttpMethod.Delete);
                return null!;
            });
        }
    }
}

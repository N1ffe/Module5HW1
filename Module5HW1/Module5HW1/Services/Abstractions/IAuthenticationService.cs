using Module5HW1.Models;

namespace Module5HW1.Services.Abstractions
{
    public interface IAuthenticationService
    {
        Task<RegisterResult> Register(string email, string password);
        Task<LoginResult> Login(string email, string password);
    }
}

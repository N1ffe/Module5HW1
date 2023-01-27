using Module5HW1.Models;

namespace Module5HW1.Services.Abstractions
{
    public interface IUserService
    {
        Task<User> GetUser(int id);
        Task<StatusCollection<User>> GetUsersByPage(int page);
        Task<StatusCollection<User>> GetUsersByPageWithDelay(int delay);
    }
}

using Module5HW1.Services.Abstractions;
using Newtonsoft.Json;

namespace Module5HW1
{
    public class App
    {
        private readonly IUserService _userService;
        public App(IUserService userService)
        {
            _userService = userService;
        }
        public async Task Start()
        {
            var users = Task.Run(async () => await _userService.GetUsersByPage(2));
            var user2 = Task.Run(async () => await _userService.GetUser(2));
            var user23 = Task.Run(async () => await _userService.GetUser(23));
            var delayedUser = Task.Run(async () => await _userService.GetUsersByPageWithDelay(3));
            await Task.WhenAll(
                users,
                user2,
                user23,
                delayedUser);
            Console.WriteLine(JsonConvert.SerializeObject(users.Result));
            Console.WriteLine(JsonConvert.SerializeObject(user2.Result));
            Console.WriteLine(JsonConvert.SerializeObject(user23.Result));
            Console.WriteLine(JsonConvert.SerializeObject(delayedUser.Result));
        }
    }
}

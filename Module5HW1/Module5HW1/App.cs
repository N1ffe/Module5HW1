using Module5HW1.Services.Abstractions;
using Newtonsoft.Json;

namespace Module5HW1
{
    public class App
    {
        private readonly IUserService _userService;
        private readonly IEmployeeService _employeeService;
        public App(IUserService userService, IEmployeeService employeeService)
        {
            _userService = userService;
            _employeeService = employeeService;
        }
        public async Task Start()
        {
            var users = Task.Run(async () => await _userService.GetUsersByPage(2));
            var user2 = Task.Run(async () => await _userService.GetUser(2));
            var user23 = Task.Run(async () => await _userService.GetUser(23));
            var delayedUser = Task.Run(async () => await _userService.GetUsersByPageWithDelay(3));
            var createdEmployee = Task.Run(async () => await _employeeService.CreateEmployee("morpheus", "leader"));
            var putUpdatedEmployee = Task.Run(async () => await _employeeService.UpdateEmployee(2, "morpheus", "zion resident"));
            var patchUpdatedEmployee = Task.Run(async () => await _employeeService.ModifyEmployee(2, "morpheus", "zion resident"));
            var deletedEmployee = Task.Run(async () => await _employeeService.RemoveEmployee(2));
            await Task.WhenAll(
                users,
                user2,
                user23,
                delayedUser,
                createdEmployee,
                putUpdatedEmployee,
                patchUpdatedEmployee,
                deletedEmployee);
            Console.WriteLine(JsonConvert.SerializeObject(users.Result));
            Console.WriteLine(JsonConvert.SerializeObject(user2.Result));
            Console.WriteLine(JsonConvert.SerializeObject(user23.Result));
            Console.WriteLine(JsonConvert.SerializeObject(delayedUser.Result));
            Console.WriteLine(JsonConvert.SerializeObject(createdEmployee.Result));
            Console.WriteLine(JsonConvert.SerializeObject(putUpdatedEmployee.Result));
            Console.WriteLine(JsonConvert.SerializeObject(patchUpdatedEmployee.Result));
            Console.WriteLine(JsonConvert.SerializeObject(deletedEmployee.Result));
        }
    }
}

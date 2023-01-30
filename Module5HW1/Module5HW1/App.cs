using Module5HW1.Services.Abstractions;
using Newtonsoft.Json;

namespace Module5HW1
{
    public class App
    {
        private readonly IUserService _userService;
        private readonly IEmployeeService _employeeService;
        private readonly IAuthenticationService _authenticationService;
        public App(IUserService userService, IEmployeeService employeeService, IAuthenticationService authenticationService)
        {
            _userService = userService;
            _employeeService = employeeService;
            _authenticationService = authenticationService;
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
            var register1 = Task.Run(async () => await _authenticationService.Register("eve.holt@reqres.in", "pistol"));
            var register2 = Task.Run(async () => await _authenticationService.Register("sydney@fife", null));
            var login1 = Task.Run(async () => await _authenticationService.Login("eve.holt@reqres.in", "cityslicka"));
            var login2 = Task.Run(async () => await _authenticationService.Login("peter@klaven", null));
            await Task.WhenAll(
                users,
                user2,
                user23,
                delayedUser,
                createdEmployee,
                putUpdatedEmployee,
                patchUpdatedEmployee,
                deletedEmployee,
                register1,
                register2,
                login1,
                login2);
            Console.WriteLine(JsonConvert.SerializeObject(users.Result));
            Console.WriteLine(JsonConvert.SerializeObject(user2.Result));
            Console.WriteLine(JsonConvert.SerializeObject(user23.Result));
            Console.WriteLine(JsonConvert.SerializeObject(delayedUser.Result));
            Console.WriteLine(JsonConvert.SerializeObject(createdEmployee.Result));
            Console.WriteLine(JsonConvert.SerializeObject(putUpdatedEmployee.Result));
            Console.WriteLine(JsonConvert.SerializeObject(patchUpdatedEmployee.Result));
            Console.WriteLine(JsonConvert.SerializeObject(deletedEmployee.Result));
            Console.WriteLine(JsonConvert.SerializeObject(register1.Result));
            Console.WriteLine(JsonConvert.SerializeObject(register2.Result));
            Console.WriteLine(JsonConvert.SerializeObject(login1.Result));
            Console.WriteLine(JsonConvert.SerializeObject(login2.Result));
        }
    }
}

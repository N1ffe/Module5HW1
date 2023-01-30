using Module5HW1.Models;

namespace Module5HW1.Services.Abstractions
{
    public interface IEmployeeService
    {
        Task<Employee> CreateEmployee(string name, string job);
        Task<Employee> UpdateEmployee(int id, string name, string job);
        Task<Employee> ModifyEmployee(int id, string name, string job);
        Task<VoidResult> RemoveEmployee(int id);
    }
}

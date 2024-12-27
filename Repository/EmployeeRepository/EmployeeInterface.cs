using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<string> GetEmployeeNameByIdAsync(string id); // New method
        Task<IEnumerable<string>> GetEmployeeNamesByIdsAsync(IEnumerable<string> ids); // Keep this method
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}

using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeResponseDto>> GetAllEmployeesAsync();
        Task<EmployeeResponseDto> GetEmployeeByIdAsync(int id);
        Task<EmployeeResponseDto> AddEmployeeAsync(EmployeeRequestDto employeeRequest);
        Task<EmployeeResponseDto> UpdateEmployeeAsync(int id, EmployeeRequestDto employeeRequest);

        Task<bool> DeleteEmployeeAsync(int id);
    }
}
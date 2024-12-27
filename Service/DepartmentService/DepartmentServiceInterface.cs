using EmployeeManagementSystem.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services.DepartmentService
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentResponseDto>> GetAllDepartmentsAsync();
        Task<DepartmentResponseDto> GetDepartmentByIdAsync(int id);
        Task<DepartmentResponseDto> AddDepartmentAsync(DepartmentRequestDto departmentRequest);
        Task<DepartmentResponseDto> UpdateDepartmentAsync(int id, DepartmentRequestDto departmentRequest);
        Task<bool> DeleteDepartmentAsync(int id);
    }
}

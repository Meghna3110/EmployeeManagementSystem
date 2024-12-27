using EmployeeManagementSystem.DTOs;

namespace EmployeeManagementSystem.Service.PayrollService
{
    public interface IPayrollService
    {
        Task<IEnumerable<PayrollResponseDto>> GetAllPayrollsAsync();
        Task<PayrollResponseDto> GetPayrollByIdAsync(int id);
        Task<PayrollResponseDto> AddPayrollAsync(PayrollRequestDto payrollRequestDto);
        Task<PayrollResponseDto> UpdatePayrollAsync(int id, PayrollRequestDto payrollRequestDto);
        Task<bool> DeletePayrollAsync(int id);
    }
}

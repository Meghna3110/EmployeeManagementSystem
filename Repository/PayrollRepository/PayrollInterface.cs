using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.Repository.PayrollRepository
{
    public interface IPayrollRepository
    {
        Task<IEnumerable<Payroll>> GetAllPayrollsAsync();
        Task<Payroll> GetPayrollByIdAsync(int id);
        Task<Payroll> AddPayrollAsync(Payroll payroll);
        Task<Payroll> UpdatePayrollAsync(Payroll payroll);
        Task<bool> DeletePayrollAsync(int id);
    }

}









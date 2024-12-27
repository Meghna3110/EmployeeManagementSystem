using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Repository.PayrollRepository;

namespace EmployeeManagementSystem.Service.PayrollService
{
    public class PayrollService : IPayrollService
    {
        private readonly IPayrollRepository _payrollRepository;

        public PayrollService(IPayrollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }

        public async Task<IEnumerable<PayrollResponseDto>> GetAllPayrollsAsync()
        {
            var payrolls = await _payrollRepository.GetAllPayrollsAsync();

            return payrolls.Select(payroll => new PayrollResponseDto
            {
                Id = payroll.Id,
                EmployeeName = "Employee Name Placeholder", // Replace with logic to fetch EmployeeName if needed
                Month = payroll.Month,
                GrossSalary = payroll.GrossSalary,
                Deduction = payroll.Deduction,
                NetSalary = payroll.GrossSalary - payroll.Deduction
            });
        }

        public async Task<PayrollResponseDto> GetPayrollByIdAsync(int id)
        {
            var payroll = await _payrollRepository.GetPayrollByIdAsync(id);

            if (payroll == null)
                throw new KeyNotFoundException("Payroll record not found");

            return new PayrollResponseDto
            {
                Id = payroll.Id,
                EmployeeName = "Employee Name Placeholder", // Replace with logic to fetch EmployeeName if needed
                Month = payroll.Month,
                GrossSalary = payroll.GrossSalary,
                Deduction = payroll.Deduction,
                NetSalary = payroll.GrossSalary - payroll.Deduction
            };
        }

        public async Task<PayrollResponseDto> AddPayrollAsync(PayrollRequestDto payrollRequestDto)
        {
            var payroll = new Payroll
            {
                EmployeeId = payrollRequestDto.EmployeeId,
                Month = payrollRequestDto.Month,
                GrossSalary = payrollRequestDto.GrossSalary,
                Deduction = payrollRequestDto.Deduction,
                NetSalary = payrollRequestDto.GrossSalary - payrollRequestDto.Deduction
            };

            var createdPayroll = await _payrollRepository.AddPayrollAsync(payroll);

            return new PayrollResponseDto
            {
                Id = createdPayroll.Id,
                EmployeeName = "Employee Name Placeholder", // Replace with logic to fetch EmployeeName if needed
                Month = createdPayroll.Month,
                GrossSalary = createdPayroll.GrossSalary,
                Deduction = createdPayroll.Deduction,
                NetSalary = createdPayroll.NetSalary
            };
        }

        public async Task<PayrollResponseDto> UpdatePayrollAsync(int id, PayrollRequestDto payrollRequestDto)
        {
            var existingPayroll = await _payrollRepository.GetPayrollByIdAsync(id);

            if (existingPayroll == null)
                throw new KeyNotFoundException("Payroll record not found");

            // Update the fields
            existingPayroll.EmployeeId = payrollRequestDto.EmployeeId;
            existingPayroll.Month = payrollRequestDto.Month;
            existingPayroll.GrossSalary = payrollRequestDto.GrossSalary;
            existingPayroll.Deduction = payrollRequestDto.Deduction;
            existingPayroll.NetSalary = payrollRequestDto.GrossSalary - payrollRequestDto.Deduction;

            var updatedPayroll = await _payrollRepository.UpdatePayrollAsync(existingPayroll);

            return new PayrollResponseDto
            {
                Id = updatedPayroll.Id,
                EmployeeName = "Employee Name Placeholder", // Replace with logic to fetch EmployeeName if needed
                Month = updatedPayroll.Month,
                GrossSalary = updatedPayroll.GrossSalary,
                Deduction = updatedPayroll.Deduction,
                NetSalary = updatedPayroll.NetSalary
            };
        }

        public async Task<bool> DeletePayrollAsync(int id)
        {
            var isDeleted = await _payrollRepository.DeletePayrollAsync(id);

            if (!isDeleted)
                throw new KeyNotFoundException("Payroll record not found");

            return isDeleted;
        }
    }
}

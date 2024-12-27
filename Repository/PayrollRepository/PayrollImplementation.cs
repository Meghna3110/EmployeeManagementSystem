using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Repository.PayrollRepository;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repository.PayrollRepository
{
    public class PayrollRepository : IPayrollRepository
    {
        private readonly AppDbContext _context;

        public PayrollRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payroll>> GetAllPayrollsAsync()
        {
            return await _context.Set<Payroll>().ToListAsync();
        }

        public async Task<Payroll> GetPayrollByIdAsync(int id)
        {
            return await _context.Set<Payroll>().FindAsync(id);
        }

        public async Task<Payroll> AddPayrollAsync(Payroll payroll)
        {
            _context.Set<Payroll>().Add(payroll);
            await _context.SaveChangesAsync();
            return payroll;
        }

        public async Task<Payroll> UpdatePayrollAsync(Payroll payroll)
        {
            _context.Set<Payroll>().Update(payroll);
            await _context.SaveChangesAsync();
            return payroll;
        }

        public async Task<bool> DeletePayrollAsync(int id)
        {
            var payroll = await _context.Set<Payroll>().FindAsync(id);
            if (payroll == null) return false;

            _context.Set<Payroll>().Remove(payroll);
            await _context.SaveChangesAsync();
            return true;
        }
    }
   
}




using System.Linq;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repository.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        // The method to get employee names by their string IDs
        public async Task<IEnumerable<string>> GetEmployeeNamesByIdsAsync(IEnumerable<string> employeeIds)
        {
            return await _context.Employees
                .Where(e => employeeIds.Contains(e.EmployeeId)) // Use e.Id, which is a string
                .Select(e => e.EmployeeName) // Fetch employee name only
                .ToListAsync();
        }

        // Fetch all employees
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Set<Employee>().ToListAsync();
        }

        // Fetch employee by ID
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Set<Employee>().FindAsync(id);
        }

        // Fetch employee name by employee ID
        public async Task<string> GetEmployeeNameByIdAsync(string id)
        {
            var employee = await _context.Set<Employee>().FindAsync(id);
            return employee?.EmployeeName;
        }

        // Add a new employee
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            //_context.Set<Employee>().Add(employee);
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        // Update existing employee details
        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            _context.Set<Employee>().Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        // Delete an employee by ID
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Set<Employee>().FindAsync(id);
            if (employee == null) return false;

            _context.Set<Employee>().Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

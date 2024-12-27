using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Repository.DepartmentRepository;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repository.DepartmentRepository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Set<Department>().ToListAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _context.Set<Department>().FindAsync(id);
        }

        public async Task<Department> AddDepartmentAsync(Department department)
        {
            _context.Set<Department>().Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> UpdateDepartmentAsync(Department department)
        {
            _context.Set<Department>().Update(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var department = await _context.Set<Department>().FindAsync(id);
            if (department == null) return false;

            _context.Set<Department>().Remove(department);
            await _context.SaveChangesAsync();
            return true;
        }
    }
   
}

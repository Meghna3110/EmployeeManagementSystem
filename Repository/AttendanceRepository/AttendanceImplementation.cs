using EmployeeManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repository.AttendanceRepository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AppDbContext _context;

        public AttendanceRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendanceRecordsAsync()
        {
            return await _context.Set<Attendance>().ToListAsync();
        }

        public async Task<Attendance> GetAttendanceByIdAsync(string id)
        {
            return await _context.Set<Attendance>().FindAsync(id);
        }

        public async Task<Attendance> AddAttendanceAsync(Attendance attendance)
        {
            _context.Set<Attendance>().Add(attendance);
            await _context.SaveChangesAsync();
            return attendance;
        }

        public async Task<Attendance> UpdateAttendanceAsync(Attendance attendance)
        {
            _context.Set<Attendance>().Update(attendance);
            await _context.SaveChangesAsync();
            return attendance;
        }

        public async Task<bool> DeleteAttendanceAsync(string id)
        {
            var attendance = await _context.Set<Attendance>().FindAsync(id);
            if (attendance == null) return false;

            _context.Set<Attendance>().Remove(attendance);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

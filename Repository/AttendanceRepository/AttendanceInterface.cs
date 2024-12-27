using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.Repository.AttendanceRepository
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetAllAttendanceRecordsAsync();
        Task<Attendance> GetAttendanceByIdAsync(string id);
        Task<Attendance> AddAttendanceAsync(Attendance attendance);
        Task<Attendance> UpdateAttendanceAsync(Attendance attendance);
        Task<bool> DeleteAttendanceAsync(string id);

    }
    
}



/*public interface IAttendanceRepository
{
    Task<IEnumerable<Attendance>> GetAllAttendanceRecordsAsync();
    Task<Attendance> GetAttendanceByIdAsync(int id);
    Task<Attendance> AddAttendanceAsync(Attendance attendance);
    Task<Attendance> UpdateAttendanceAsync(Attendance attendance);
    Task<bool> DeleteAttendanceAsync(int id);
}
*/

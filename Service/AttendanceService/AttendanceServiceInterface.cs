using EmployeeManagementSystem.DTOs;

namespace EmployeeManagementSystem.Service
{
    public interface IAttendanceService
    {
        Task<AttendanceResponseDto> AddAttendanceAsync(AttendanceRequestDto requestDto);
        Task<IEnumerable<AttendanceResponseDto>> GetAllAttendancesAsync();
        Task<AttendanceResponseDto> GetAttendanceByIdAsync(string id);
        Task<AttendanceResponseDto> UpdateAttendanceAsync(string id, AttendanceRequestDto requestDto);
        Task<bool> DeleteAttendanceAsync(string id);
    }
}

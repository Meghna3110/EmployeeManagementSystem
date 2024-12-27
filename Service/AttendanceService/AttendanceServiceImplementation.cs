using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Repositories;
using EmployeeManagementSystem.Repository.AttendanceRepository;
using EmployeeManagementSystem.Repository.EmployeeRepository;

namespace EmployeeManagementSystem.Service
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository, IEmployeeRepository employeeRepository)
        {
            _attendanceRepository = attendanceRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<AttendanceResponseDto> AddAttendanceAsync(AttendanceRequestDto requestDto)
        {
            var attendance = new Attendance
            {
                EmployeeId = requestDto.EmployeeId,  // EmployeeId is now a string
                AttendanceDateTime = requestDto.AttendanceDateTime,
                Status = Enum.Parse<AttendanceStatus>(requestDto.Status)
            };

            var createdAttendance = await _attendanceRepository.AddAttendanceAsync(attendance);

            var employeeName = await _employeeRepository.GetEmployeeNameByIdAsync(createdAttendance.EmployeeId);

            return new AttendanceResponseDto
            {
                Id = createdAttendance.Id,
                EmployeeId = createdAttendance.EmployeeId,
                EmployeeName = employeeName,
                AttendanceDateTime = createdAttendance.AttendanceDateTime,
                Status = createdAttendance.Status.ToString()
            };
        }

        public async Task<IEnumerable<AttendanceResponseDto>> GetAllAttendancesAsync()
        {
            var attendances = await _attendanceRepository.GetAllAttendanceRecordsAsync();

            // Fetch employee names in bulk
            var employeeIds = attendances.Select(a => a.EmployeeId).Distinct();  // EmployeeId is now a string
            var employeeNameMappings = new Dictionary<string, string>();

            foreach (var employeeId in employeeIds)
            {
                var employeeName = await _employeeRepository.GetEmployeeNameByIdAsync(employeeId);
                employeeNameMappings[employeeId] = employeeName;
            }

            // Map model list to response DTO list
            return attendances.Select(a => new AttendanceResponseDto
            {
                Id = a.Id,
                EmployeeId = a.EmployeeId,
                EmployeeName = employeeNameMappings.ContainsKey(a.EmployeeId) ? employeeNameMappings[a.EmployeeId] : "Unknown",
                AttendanceDateTime = a.AttendanceDateTime,
                Status = a.Status.ToString()
            });
        }

        // Updated method signature for string id instead of int id
        public async Task<AttendanceResponseDto> GetAttendanceByIdAsync(string id)
        {
            var attendance = await _attendanceRepository.GetAttendanceByIdAsync(id);

            if (attendance == null)
                throw new KeyNotFoundException($"Attendance record with ID {id} not found.");

            var employeeName = await _employeeRepository.GetEmployeeNameByIdAsync(attendance.EmployeeId);

            return new AttendanceResponseDto
            {
                Id = attendance.Id,
                EmployeeId = attendance.EmployeeId,
                EmployeeName = employeeName,
                AttendanceDateTime = attendance.AttendanceDateTime,
                Status = attendance.Status.ToString()
            };
        }

        // Updated method signature for string id instead of int id
        public async Task<AttendanceResponseDto> UpdateAttendanceAsync(string id, AttendanceRequestDto requestDto)
        {
            var existingAttendance = await _attendanceRepository.GetAttendanceByIdAsync(id);

            if (existingAttendance == null)
                throw new KeyNotFoundException($"Attendance record with ID {id} not found.");

            existingAttendance.EmployeeId = requestDto.EmployeeId;
            existingAttendance.AttendanceDateTime = requestDto.AttendanceDateTime;
            existingAttendance.Status = Enum.Parse<AttendanceStatus>(requestDto.Status);

            var updatedAttendance = await _attendanceRepository.UpdateAttendanceAsync(existingAttendance);

            var employeeName = await _employeeRepository.GetEmployeeNameByIdAsync(updatedAttendance.EmployeeId);

            return new AttendanceResponseDto
            {
                Id = updatedAttendance.Id,
                EmployeeId = updatedAttendance.EmployeeId,
                EmployeeName = employeeName,
                AttendanceDateTime = updatedAttendance.AttendanceDateTime,
                Status = updatedAttendance.Status.ToString()
            };
        }

        // Updated method signature for string id instead of int id
        public async Task<bool> DeleteAttendanceAsync(string id)
        {
            var deleted = await _attendanceRepository.DeleteAttendanceAsync(id);
            if (!deleted)
                throw new KeyNotFoundException($"Attendance record with ID {id} not found.");

            return true;
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Model
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeId { get; set; } // Changed from string to int
        public required DateTime AttendanceDateTime { get; set; } = DateTime.Now;
        public required AttendanceStatus Status { get; set; } = AttendanceStatus.Present;
    }

    public enum AttendanceStatus
    {
        Present,
        Absent,
        Late,
        Leave
    }
}

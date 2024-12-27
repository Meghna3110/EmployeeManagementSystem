namespace EmployeeManagementSystem.DTOs
{
    public class AttendanceRequestDto
    {
        public string EmployeeId { get; set; } // Changed from string to int
        public DateTime AttendanceDateTime { get; set; }
        public string Status { get; set; } // Enum as a string
        public int DepartmentId { get; set; }
    }
}
namespace EmployeeManagementSystem.DTOs
{
    public class AttendanceResponseDto
    {
        public int Id { get; set; }
        public required string EmployeeId { get; set; } // Changed from string to int
        public required string EmployeeName { get; set; }
        public DateTime AttendanceDateTime { get; set; }
        public string Status { get; set; } // Enum as a string
    }
}

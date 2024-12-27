using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.DTOs
{
    public class EmployeeResponseDto
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public int Age { get; set; }
        public string DateOfBirth { get; set; }
        public string DepartmentName { get; set; }
        public string RoleName { get; set; }
        public decimal Salary { get; set; }
        public DateOnly CreateDate { get; set; }

    }
}

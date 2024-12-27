using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.DTOs
{
    public class EmployeeRequestDto
    {
        public string EmployeeName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string DateOfBirth { get; set; }
        public string DepartmentName { get; set; }
        public string RoleName { get; set; }

    }
}

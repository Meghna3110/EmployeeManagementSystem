using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public required string EmployeeName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string EmailId { get; set; }
        public int Age { get; set; }
        public string DateOfBirth { get; set; }
        public string DepartmentName { get; set; }
        public string RoleName { get; set; } = "DefaultRole";
        public decimal Salary { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Employee()
        {
            CreatedDate = DateTime.UtcNow;
        }
        public void UpdateTimestamp()
        {
            UpdatedDate = DateTime.UtcNow;
        }
    }
}

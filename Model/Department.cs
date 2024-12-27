using System.ComponentModel.DataAnnotations;
namespace EmployeeManagementSystem.Model
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

    }
}

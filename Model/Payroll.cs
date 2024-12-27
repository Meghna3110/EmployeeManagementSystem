using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Model
{
    public class Payroll
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public required string Month { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal Deduction { get; set; }
        public decimal NetSalary { get; set; }
    }
}

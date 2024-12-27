namespace EmployeeManagementSystem.DTOs
{
    public class PayrollRequestDto
    {
        public string EmployeeId { get; set; } // FK for Employee
        public string Month { get; set; } // Format: "MMM-YYYY" (e.g., "Dec-2024")
        public decimal GrossSalary { get; set; }
        public decimal Deduction { get; set; }
    }
}

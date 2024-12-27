namespace EmployeeManagementSystem.DTOs
{
    public class PayrollResponseDto
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string Month { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal Deduction { get; set; }
        public decimal NetSalary { get; set; }
    }
}

using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Repositories;
using EmployeeManagementSystem.Repository.EmployeeRepository;
using EmployeeManagementSystem.Services;

namespace EmployeeManagementSystem.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeeResponseDto>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return employees.Select(e => new EmployeeResponseDto
            {
                EmployeeId = e.EmployeeId,
                EmployeeName = e.EmployeeName,
                PhoneNumber = e.PhoneNumber,
                EmailId = e.EmailId,
                Age = e.Age,
                DateOfBirth = e.DateOfBirth,
                DepartmentName = e.DepartmentName,
                RoleName = e.RoleName,
                Salary = e.Salary
            });
        }

        public async Task<EmployeeResponseDto> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
                throw new KeyNotFoundException($"Employee with ID {id} not found.");

            return new EmployeeResponseDto
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                PhoneNumber = employee.PhoneNumber,
                EmailId = employee.EmailId,
                Age = employee.Age,
                DateOfBirth = employee.DateOfBirth,
                DepartmentName = employee.DepartmentName,
                RoleName = employee.RoleName,
                Salary = employee.Salary
            };
        }

        public async Task<EmployeeResponseDto> AddEmployeeAsync(EmployeeRequestDto employeeRequest)
        {
            //var employee = new Employee(employeeRequest.RoleName ?? "DefaultRole")
            var employee = new Employee
            {
                DepartmentName = employeeRequest.DepartmentName,
                EmployeeId = "wwww",
                EmployeeName = employeeRequest.EmployeeName,
                EmailId = employeeRequest.EmailId,
                PhoneNumber = employeeRequest.PhoneNumber,
                Age = employeeRequest.Age,
                DateOfBirth = employeeRequest.DateOfBirth,
                RoleName = employeeRequest.RoleName ?? "DefaultRole",
                CreatedDate = DateTime.UtcNow
            };


            var addedEmployee = await _employeeRepository.AddEmployeeAsync(employee);
            return new EmployeeResponseDto
            {
                EmployeeId = addedEmployee.EmployeeId,
                EmployeeName = addedEmployee.EmployeeName,
                PhoneNumber = addedEmployee.PhoneNumber,
                EmailId = addedEmployee.EmailId,
                Age = addedEmployee.Age,
                DateOfBirth = addedEmployee.DateOfBirth,
                DepartmentName = addedEmployee.DepartmentName,
                RoleName = addedEmployee.RoleName,
                Salary = addedEmployee.Salary
            };
        }

        public async Task<EmployeeResponseDto> UpdateEmployeeAsync(int id, EmployeeRequestDto employeeRequest)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
                throw new KeyNotFoundException($"Employee with ID {id} not found.");

            employee.EmployeeName = employeeRequest.EmployeeName;
            employee.EmailId = employeeRequest.EmailId;
            employee.PhoneNumber = employeeRequest.PhoneNumber;
            employee.Age = employeeRequest.Age;
            employee.DateOfBirth = employeeRequest.DateOfBirth;
            employee.UpdateTimestamp(); // Update the timestamp

            var updatedEmployee = await _employeeRepository.UpdateEmployeeAsync(employee);
            return new EmployeeResponseDto
            {
                EmployeeId = updatedEmployee.EmployeeId,
                EmployeeName = updatedEmployee.EmployeeName,
                PhoneNumber = updatedEmployee.PhoneNumber,
                EmailId = updatedEmployee.EmailId,
                Age = updatedEmployee.Age,
                DateOfBirth = updatedEmployee.DateOfBirth,
                DepartmentName = updatedEmployee.DepartmentName,
                RoleName = updatedEmployee.RoleName,
                Salary = updatedEmployee.Salary
            };
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            return await _employeeRepository.DeleteEmployeeAsync(id);
        }
    }

}
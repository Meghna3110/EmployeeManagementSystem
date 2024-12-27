using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Services;
using EmployeeManagementSystem.Services.EmployeeService;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployeesAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error retrieving employees: {ex.Message}" });
            }
        }

        [HttpGet("GetEmployeeById/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByIdAsync(id);
                return Ok(employee);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error retrieving employee: {ex.Message}" });
            }
        }

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromForm] EmployeeRequestDto employeeRequest)
        {
            try
            {
                var newEmployee = await _employeeService.AddEmployeeAsync(employeeRequest);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = newEmployee.EmployeeId }, newEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error adding employee: {ex.Message}" });
            }
        }

        [HttpPut("UpdateEmployee/{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeRequestDto employeeRequest)
        {
            try
            {
                var updatedEmployee = await _employeeService.UpdateEmployeeAsync(id, employeeRequest);
                return Ok(updatedEmployee);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error updating employee: {ex.Message}" });
            }
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var isDeleted = await _employeeService.DeleteEmployeeAsync(id);
                if (!isDeleted)
                {
                    return NotFound(new { message = $"Employee with ID {id} not found." });
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error deleting employee: {ex.Message}" });
            }
        }
    }
}

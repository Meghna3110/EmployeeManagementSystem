using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Services.DepartmentService;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("GetAllDepartments")]
        public async Task<IActionResult> GetAllDepartments()
        {
            try
            {
                var departments = await _departmentService.GetAllDepartmentsAsync();
                return Ok(departments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error retrieving departments: {ex.Message}" });
            }
        }

        [HttpGet("GetDepartmentById/{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            try
            {
                var department = await _departmentService.GetDepartmentByIdAsync(id);
                return Ok(department);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error retrieving department: {ex.Message}" });
            }
        }

        [HttpPost("AddDepartment")]
        public async Task<IActionResult> AddDepartment([FromBody] DepartmentRequestDto departmentRequest)
        {
            try
            {
                var newDepartment = await _departmentService.AddDepartmentAsync(departmentRequest);
                return CreatedAtAction(nameof(GetDepartmentById), new { id = newDepartment.DepartmentId }, newDepartment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error adding department: {ex.Message}" });
            }
        }

        [HttpPut("UpdateDepartment/{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] DepartmentRequestDto departmentRequest)
        {
            try
            {
                var updatedDepartment = await _departmentService.UpdateDepartmentAsync(id, departmentRequest);
                return Ok(updatedDepartment);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error updating department: {ex.Message}" });
            }
        }

        [HttpDelete("DeleteDepartment/{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            try
            {
                var isDeleted = await _departmentService.DeleteDepartmentAsync(id);
                if (!isDeleted)
                {
                    return NotFound(new { message = $"Department with ID {id} not found." });
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error deleting department: {ex.Message}" });
            }
        }
    }
}

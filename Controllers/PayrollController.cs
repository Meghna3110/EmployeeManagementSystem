using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Service.PayrollService;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly IPayrollService _payrollService;

        public PayrollController(IPayrollService payrollService)
        {
            _payrollService = payrollService;
        }

        [HttpGet("GetAllPayrolls")]
        public async Task<IActionResult> GetAllPayrolls()
        {
            var payrolls = await _payrollService.GetAllPayrollsAsync();
            return Ok(payrolls);
        }

        [HttpGet("GetPayrollById/{id:int}")]
        public async Task<IActionResult> GetPayrollById(int id)
        {
            try
            {
                var payroll = await _payrollService.GetPayrollByIdAsync(id);
                return Ok(payroll);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost("AddPayroll")]
        public async Task<IActionResult> AddPayroll([FromBody] PayrollRequestDto payrollRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var payroll = await _payrollService.AddPayrollAsync(payrollRequestDto);
            return CreatedAtAction(nameof(GetPayrollById), new { id = payroll.Id }, payroll);
        }

        [HttpPut("UpdatePayroll/{id:int}")]
        public async Task<IActionResult> UpdatePayroll(int id, [FromBody] PayrollRequestDto payrollRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updatedPayroll = await _payrollService.UpdatePayrollAsync(id, payrollRequestDto);
                return Ok(updatedPayroll);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("DeletePayroll/{id:int}")]
        public async Task<IActionResult> DeletePayroll(int id)
        {
            try
            {
                var isDeleted = await _payrollService.DeletePayrollAsync(id);
                return Ok(new { message = "Payroll deleted successfully", isDeleted });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}

using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Service;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        // POST: api/Attendance
        [HttpPost("AddAttendanceAsync")]
        public async Task<IActionResult> AddAttendanceAsync([FromBody] AttendanceRequestDto requestDto)
        {
            try
            {
                var result = await _attendanceService.AddAttendanceAsync(requestDto);
                return CreatedAtAction(nameof(GetAttendanceByIdAsync), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/Attendance
        [HttpGet("GetAllAttendancesAsync")]
        public async Task<IActionResult> GetAllAttendancesAsync()
        {
            try
            {
                var result = await _attendanceService.GetAllAttendancesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/Attendance/5
        [HttpGet("GetAttendanceByIdAsync/{id}")]
        public async Task<IActionResult> GetAttendanceByIdAsync(string id)
        {
            try
            {
                var result = await _attendanceService.GetAttendanceByIdAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Attendance record with ID {id} not found." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/Attendance/5
        [HttpPut("UpdateAttendanceAsync/{id}")]
        public async Task<IActionResult> UpdateAttendanceAsync(string id, [FromBody] AttendanceRequestDto requestDto)
        {
            try
            {
                var result = await _attendanceService.UpdateAttendanceAsync(id, requestDto);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Attendance record with ID {id} not found." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/Attendance/5
        [HttpDelete("DeleteAttendanceAsync/{id}")]
        public async Task<IActionResult> DeleteAttendanceAsync(string id)
        {
            try
            {
                var deleted = await _attendanceService.DeleteAttendanceAsync(id);
                return Ok(new { message = $"Attendance record with ID {id} successfully deleted." });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Attendance record with ID {id} not found." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

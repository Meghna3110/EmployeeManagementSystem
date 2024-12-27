using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Repository.DepartmentRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // Get all departments
        public async Task<IEnumerable<DepartmentResponseDto>> GetAllDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAllDepartmentsAsync();
            var departmentResponseDtos = new List<DepartmentResponseDto>();

            foreach (var department in departments)
            {
                departmentResponseDtos.Add(new DepartmentResponseDto
                {
                    DepartmentId = department.DepartmentId,
                    DepartmentName = department.DepartmentName
                });
            }

            return departmentResponseDtos;
        }

        // Get department by ID
        public async Task<DepartmentResponseDto> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                throw new KeyNotFoundException($"Department with ID {id} not found.");
            }

            return new DepartmentResponseDto
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName
            };
        }

        // Add a new department
        public async Task<DepartmentResponseDto> AddDepartmentAsync(DepartmentRequestDto departmentRequest)
        {
            var department = new Department
            {
                DepartmentName = departmentRequest.DepartmentName
            };

            var addedDepartment = await _departmentRepository.AddDepartmentAsync(department);

            return new DepartmentResponseDto
            {
                DepartmentId = addedDepartment.DepartmentId,
                DepartmentName = addedDepartment.DepartmentName
            };
        }

        // Update an existing department
        public async Task<DepartmentResponseDto> UpdateDepartmentAsync(int id, DepartmentRequestDto departmentRequest)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                throw new KeyNotFoundException($"Department with ID {id} not found.");
            }

            department.DepartmentName = departmentRequest.DepartmentName;

            var updatedDepartment = await _departmentRepository.UpdateDepartmentAsync(department);

            return new DepartmentResponseDto
            {
                DepartmentId = updatedDepartment.DepartmentId,
                DepartmentName = updatedDepartment.DepartmentName
            };
        }

        // Delete a department by ID
        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            return await _departmentRepository.DeleteDepartmentAsync(id);
        }
    }
}

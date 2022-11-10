using System;
namespace firstApiTask.DTOs.EmployeeDtos
{
    public class EmployeeCreateDto
    {
        public string Name { get; set; } = null!;
        public string? Surname { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
    }
}


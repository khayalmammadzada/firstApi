using System;
namespace firstApiTask.DTOs.EmployeeDtos
{
    public class EmployeeUpdateDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }
        public int? DepartmentId { get; set; }
    }
}


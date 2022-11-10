using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using firstApiTask.DataAccess;
using firstApiTask.DTOs.EmployeeDtos;
using firstApiTask.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace firstApiTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public EmployeesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _dbContext.Employees.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            Employee? employee = await _dbContext.Employees.FindAsync(id);
            if (employee is null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EmployeeCreateDto employee)
        {
            _dbContext.Employees.Add(new Employee
            {
                Age = employee.Age,
                Name = employee.Name,
                Surname = employee.Surname,
                DepartmentId=employee.DepartmentId
            });
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id}/update")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] EmployeeUpdateDto updateDto)
        {
            Employee? employeeDb = await _dbContext.Employees.FindAsync(id);
            if (employeeDb is null) return NotFound();
            employeeDb.Age = updateDto.Age == 0 ? employeeDb.Age : updateDto.Age;
            employeeDb.Surname = updateDto.Surname;
            employeeDb.Name = updateDto.Name is null ? employeeDb.Name : updateDto.Name;
            employeeDb.DepartmentId = updateDto.DepartmentId == 0 ? employeeDb.DepartmentId : updateDto.Age;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            Employee? employeeDb = await _dbContext.Employees.FindAsync(id);
            if (employeeDb is null) return NotFound();
            _dbContext.Employees.Remove(employeeDb);
            await _dbContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "Employee Deleted",
                StatusCode = StatusCodes.Status200OK,
                employeeDb.Id
            });
        }





    }
}


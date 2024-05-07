using Microsoft.AspNetCore.Mvc;
using WebApplication2.Controller;
using WebApplication2.Data.Models;
using WebApplication2.Data;
using WebApplication2.Controller.Services.Contracts;
using Microsoft.AspNetCore.Authentication;
using WebApplication2.Models;
using WebApplication2.Controller.Services.Servic1;
using WebApplication2.Model;

namespace WebApplication2.Controller.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly DataContext _context;
        private readonly IEmployeeServices EmployeeService;
        public EmployeeController(DataContext context, IEmployeeServices EmployeeService)
        {
            _context = context;
            this.EmployeeService = EmployeeService;
        }
        [HttpGet("GetAllEmlopyee")]
        public async Task<ActionResult<List<Employee>>> GetAllEmployee()
        {
            var employee = await EmployeeService.GetAllEmployee();

            return Ok(employee);
        }
        [HttpGet("GetEmployee/{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(Guid id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost("AddEmployee")]
        public async Task<ActionResult<Employee>> AddEmployee(EmployeeRequesModel employee)
        {
            try
            {
                var createdEmployee = await EmployeeService.AddEmployee(employee);
                return Ok(createdEmployee);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("UpdateEmployee/{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, EmployeeRequesModel employee)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            await EmployeeService.UpdateEmployee(id, employee);
            return Ok(id);
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            await EmployeeService.DeleteEmployee(id);
            return NoContent();
        }

    }
}

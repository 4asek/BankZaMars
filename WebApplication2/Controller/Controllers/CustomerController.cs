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
    public class CustomerController : ControllerBase
    {
        
        private readonly DataContext _context;
        private readonly ICustomerServices CustomerService;
        public CustomerController(DataContext context, ICustomerServices CustomerService)
        {
            _context = context;
            this.CustomerService = CustomerService;
        }
        [HttpGet("GetAllCustomers")]
        public async Task<ActionResult<List<Customer>>> GetAllCustomer()
        {
            var customer = await CustomerService.GetAllCustomers();

            return Ok(customer);
        }
        [HttpGet("GetCustomer/{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(Guid id)
        {
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost("AddCustomer")]
        public async Task<ActionResult<Customer>> AddCustomer(CustomerRequesModel customer)
        {
            try
            {
                var createdCustomer = await CustomerService.AddCustomer(customer);
                return Ok(createdCustomer);
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
        [HttpDelete("DeleteCustomer/{id}")]
        public async Task<IActionResult> UpdateCustomers(Guid id, CustomerRequesModel customer)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            await CustomerService.UpdateCustomer(id, customer);
            return Ok(id);
        }

        [HttpPut("UpdateCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            await CustomerService.DeleteCustomer(id);
            return NoContent();
        }

    }
}

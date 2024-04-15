using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data.Models;
using WebApplication2.Data;


namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
        [ApiController]
        public class BankController : ControllerBase
        {
            private readonly DataContext _context;

            public BankController(DataContext context)
            {
                _context = context;
            }
            [HttpGet]
            public async Task<ActionResult<List<Customer>>> GetAllCustomers()
            {
                var customer = await _context.Customer.ToListAsync();

                return Ok(customer);
            }

            [HttpPost]
            public async Task<ActionResult<List<Customer>>> AddCustomer(Customer customer)
            {
                _context.Customer.Add(customer);
                await _context.SaveChangesAsync();

                return Ok(await GetAllCustomers());
            }

        }
    }


using Microsoft.AspNetCore.Mvc;
using WebApplication2.Controller;
using WebApplication2.Data.Models;
using WebApplication2.Data;
using WebApplication2.Controllers.Services.Contraxts;
using WebApplication2.Controller.Services.Contracts;
using Microsoft.AspNetCore.Authentication;
using WebApplication2.Models;
using WebApplication2.Controller.Services.Servic1;
using WebApplication2.Model;

namespace WebApplication2.Controller.Controllers
{

    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        /*
        private readonly DataContext _context;
        private readonly IAccountServices accountService;

        public AccountController(DataContext context, IAccountServices accountService)
        {
            _context = context;
            this.accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Account>>> GetAllAccount() 
        {
            var account = await accountService.GetAllAccounts();

            return Ok(account);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(Guid id) 
        {
            var account = await _context.Account.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpPost]
        public async Task<ActionResult<Account>> AddAccount(AccountRequesModel account)
        {
            try
            {
                var createdAccount = await IAccountServices.AddAccount(account);
                return Ok(createdAccount);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(Guid id, Account customer) 
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            await accountService.UpdateAccount(id, customer);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(Guid id) 
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            await accountService.DeleteAccount(id);
            return NoContent();
        }
        */
    }
}

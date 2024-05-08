using Microsoft.AspNetCore.Mvc;
using WebApplication2.Controller.Services.Contracts;
using WebApplication2.Controller.Services.Servic1;
using WebApplication2.Controllers.Services.Contraxts;
using WebApplication2.Data;
using WebApplication2.Model;
using WebApplication2.Models;

namespace ProjectBank.Controller.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ITransactionServices transactionService;

        public TransactionController(DataContext context, ITransactionServices transactionService)
        {
            _context = context;
            this.transactionService = transactionService;
        }

        [HttpGet("GetAllTransactions")]
        public async Task<ActionResult<List<Transactions>>> GetAllTransaction() //work
        {
            var transactions = await transactionService.GetAllTransaction();

            return Ok(transactions);
        }

        [HttpGet("GetTransactions/{id}")]
        public async Task<ActionResult<Transactions>> GetTransaction(Guid id) //work
        {
            var transactions = await _context.Transactions.FindAsync(id);
            if (transactions == null)
            {
                return NotFound();
            }
            return Ok(transactions);
        }


        [HttpPost("AddTransactions")]
        public async Task<ActionResult<Transactions>> AddTransactions(TransactionRequesModel transaction) //тут
        {
            try
            {
                var createdTransaction = await transactionService.AddTransactions(transaction);
                return Ok(createdTransaction);
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


        [HttpPut("UpdateTransaction/{id}")]
        public async Task<IActionResult> UpdateTransactions(Guid id, TransactionRequesModel transaction) //Work
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            await transactionService.UpdateTransactions(id, transaction);
            return Ok(id);
        }


        [HttpDelete("DeleteTransactions/{id}")]
        public async Task<IActionResult> DeleteTransactions(Guid id) //work
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            await transactionService.DeleteTransactions(id);
            return NoContent();
        }
    }
}


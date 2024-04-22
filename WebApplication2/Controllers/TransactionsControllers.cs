using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data.Models;
using WebApplication2.Data;
//interface
//
namespace WebApplication2.Controllers
{
    public class TransactionController : ControllerBase
    {
        private readonly DataContext _context;

        public TransactionController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Transaction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transactions>>> GetTransaction()
        {
            return await _context.Transactions.ToListAsync();
        }

        // GET: api/Transaction/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transactions>> GetTransaction(Guid id)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        // POST: api/Transaction
        [HttpPost]
        public async Task<ActionResult<Transactions>> CreateTransaction(Transactions transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettransaction", new { id = transaction.Id }, transaction);
        }

        // PUT: api/Transaction/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(Guid id, Transactions transaction)
        {
            if (id != transaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(transaction).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Transaction/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(Guid id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

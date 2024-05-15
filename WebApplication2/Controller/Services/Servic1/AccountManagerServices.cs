using Microsoft.AspNetCore.Mvc;
using WebApplication2.Controller.Services.Contracts;
using WebApplication2.Controllers.Services.Contraxts;

namespace WebApplication2.Controller.Services.Servic1
{
    public class AccountManagerServices
    {
        [ApiController]
        [Route("api/[controller]")]
        public class TransactionController : ControllerBase
        {
            private readonly IAccountTransferService _transactionService;

            public TransactionController(IAccountTransferService transactionService)
            {
                _transactionService = transactionService;
            }

            [HttpPost("transfer")]
            public IActionResult TransferMoney([FromBody] TransferRequest request)
            {
                if (_transactionService.TransferMoney(request.SourceAccountId, request.TargetAccountId, request.Amount))
                {
                    return Ok(new { message = $"Переказано {request.Amount} з акаунту {request.SourceAccountId} на акаунт {request.TargetAccountId}" });
                }
                else
                {
                    return BadRequest("Переказ не був виконаний.");
                }
            }

            [HttpGet("balance/{accountId}")]
            public IActionResult GetAccountBalance(string accountId)
            {
                var balance = _transactionService.GetSourceAccountBalance(accountId);
                return Ok(new { balance });
            }
        }

        public class TransferRequest
        {
            public string SourceAccountId { get; set; }
            public string TargetAccountId { get; set; }
            public decimal Amount { get; set; }
        }
    }
}

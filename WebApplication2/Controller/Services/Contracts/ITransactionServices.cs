using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data.Models;
using WebApplication2.Model;
using WebApplication2.Models;

namespace WebApplication2.Controllers.Services.Contraxts
{
    public interface ITransactionServices
    {
        Task<ActionResult<List<Transactions>>> GetAllTransaction(); 
        Task <TransactionRequesModel> GetTransaction(Guid id);
        Task<Transactions> AddTransactions(TransactionRequesModel transaction);
        Task<Guid> UpdateTransactions(Guid id, TransactionRequesModel requestModel);
        Task<Guid> DeleteTransactions(Guid id);
    }
}

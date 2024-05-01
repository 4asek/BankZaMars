using WebApplication2.Data.Models;
using WebApplication2.Models;

namespace WebApplication2.Controllers.Services.Contraxts
{
    public interface ITransactionServices
    {
        Task CreateTransaction(Transactions transactions);
        Task<IEnumerable<Transactions>> GetAllTransaction();
        Task<Transactions> GetTransactionsById(Guid id);
        Task UpdateTransactions(Transactions transactions);
        Task DeleteTransactions(Guid id);
    }
}

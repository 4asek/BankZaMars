using WebApplication2.Data.Models;

namespace WebApplication2.Services.Contraxts
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

using WebApplication2.Data.Models;

namespace WebApplication2.Services.Contraxts
{ 
    public interface IAccountServices
    {
        Task CreateAccount(Account account);
        Task<IEnumerable<Account>> GetAllAccounts();
        Task<Account> GetAccountById(Guid id);
        Task UpdateAccount(Account account);
        Task DeleteAccount(Guid id);
    }
}

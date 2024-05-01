using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data.Models;
using WebApplication2.Model;
using WebApplication2.Models;

namespace WebApplication2.Controller.Services.Contracts
{
    public interface IAccountServices
    {
        Task CreateAccount(Account account);
        Task<ActionResult<List<Account>>> GetAllAccounts();
        Task<Account> GetAccountById(Guid id);
        Task UpdateAccount(Guid id, Account account);
        Task DeleteAccount(Guid id);
        Task <Account> AddAccounts(AccountRequesModel account);
    }
}

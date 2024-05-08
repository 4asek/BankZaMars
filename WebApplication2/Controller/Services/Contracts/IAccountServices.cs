using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data.Models;
using WebApplication2.Model;
using WebApplication2.Models;

namespace WebApplication2.Controller.Services.Contracts
{
    public interface IAccountServices
    {
        Task<ActionResult<List<Account>>> GetAllAccount();
        Task<AccountRequesModel> GetAccount(Guid id);
        Task<Account> AddAccount(AccountRequesModel account);
        Task<Guid> UpdateAccount(Guid id, AccountRequesModel account);
        Task<Guid> DeleteAccount(Guid id);
    }
}

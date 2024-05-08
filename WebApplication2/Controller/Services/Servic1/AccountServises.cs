using Microsoft.AspNetCore.Mvc;
using WebApplication2.Controller.Services.Contracts;
using WebApplication2.Data.Models;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Controller.Services.Servic1
{
    public class AccountService : IAccountServices
    {
        private readonly DataContext _context;

        public AccountService(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<Account>>> GetAllAccount()
        {
            var account = await _context.Account.ToListAsync();

            return account;
        }

        public async Task<AccountRequesModel> GetAccount(Guid id)
        {
            var account = await _context.Account.FindAsync(id);

            if (account == null)
            {
                return null;
            }

            var res = MapRequestToDB(account);

            return res;
        }

        public async Task<Account> AddAccount(AccountRequesModel account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            var res = MapRequestToAccount(account);

            _context.Account.AddAsync(res);
            await _context.SaveChangesAsync();

            return res;
        }

        public async Task<Guid> DeleteAccount(Guid id)
        {
            var account = await _context.Account.FindAsync(id);
            if (account == null)
            {
                return Guid.Empty;
            }

            account.EmployeeID = Guid.Empty;
            account.CustomerID = Guid.Empty;
            _context.Account.Remove(account);
            await _context.SaveChangesAsync();

            return id;
        }


        public async Task<Guid> UpdateAccount(Guid id, AccountRequesModel requestModel)
        {
            var account = await _context.Account.FindAsync(id);
            if (account == null)
            {
                return Guid.Empty;
            }
            account = MapRequestToSet(account, requestModel);
            _context.Account.Update(account);
            await _context.SaveChangesAsync();

            return id;
        }


        private Account MapRequestToAccount(AccountRequesModel requestModel)
        {
            var account = new Account();
            account.Id = Guid.NewGuid();
            account.Name = requestModel.Name;
            account.LastName  = requestModel.LastName;
            account.Balance = requestModel.Balance;
            account.EmployeeID = requestModel.EmployeeID;
            account.CustomerID = requestModel.CustomerID;

            return account;
        }

        private AccountRequesModel MapRequestToDB(Account account)
        {
            var requestModel = new AccountRequesModel();
            requestModel.Name = account.Name;
            requestModel.LastName = account.LastName;
            requestModel.Balance = account.Balance;
            requestModel.EmployeeID = account.EmployeeID;
            requestModel.CustomerID = account.CustomerID;

            return requestModel;
        }

        private Account MapRequestToSet(Account res, AccountRequesModel account)
        {
            res.Name = account.Name;
            res.LastName = account.LastName;
            res.Balance = account.Balance;
            res.EmployeeID = account.EmployeeID;
            res.CustomerID = account.CustomerID;

            return res;
        }
    }
}

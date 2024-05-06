//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using WebApplication2.Controller.Services.Contracts;
//using WebApplication2.Data;
//using WebApplication2.Data.Models;
//using WebApplication2.Model;
//using WebApplication2.Models;

//namespace WebApplication2.Controller.Services.Servic1
//{

//    [Route("api/account")]
//    [ApiController]
//    public class AccountServices : IAccountServices
//    {
//        private readonly DataContext _context;

//        public AccountServices(DataContext context)
//        {
//            _context = context;
//        }

//        public async Task<Account> AddAccounts(AccountRequesModel account)
//        {
//            if (account == null)
//            {
//                throw new ArgumentNullException(nameof(account));
//            }
//            var res = MapRequestToAccount(account);

//            _context.Account.AddAsync(res); 
//            await _context.SaveChangesAsync();

//            return res;
//        }

//        Task IAccountServices.CreateAccount(Account account)
//        {
//            throw new NotImplementedException();
//        }

//        async Task IAccountServices.DeleteAccount(Guid id)
//        {
//            var account = await _context.Account.FindAsync(id);

//            if (account == null)
//            {
//                throw new ArgumentException($"Рахунок з ID {id} не знайдено.");
//            }

//            _context.Account.Remove(account);
//            await _context.SaveChangesAsync();
//        }

//        async Task<Account> IAccountServices.GetAccountById(Guid id)
//        {
//            return await _context.Account.FindAsync(id);
//        }

//        public async Task<ActionResult<List<Account>>> GetAllAccounts()
//        {
//            var accounts = await _context.Account.ToListAsync();

//            return accounts;
//        }

//        async Task <Guid> UpdateAccount(Guid id, AccountRequesModel requesModel)
//        {

//            var account = await _context.Account.FindAsync(id);
//            if (account == null)
//            {
//                throw new ArgumentException($"Рахунок з ID {id} не знайдено.");
//            }
//            account = MapRequestToSet(account, requesModel);
//            _context.Account.Update(account);
//            await _context.SaveChangesAsync();

//            return id;
//        }

//        private Account MapRequestToAccount(AccountRequesModel requestModel)
//        {
//            var account = new Account();
//            account.Id = Guid.NewGuid();
//            account.Name = requestModel.Name;
//            account.LastName = requestModel.LastName;
//            account.Balance = requestModel.Balance;
//            account.City = requestModel.City;
//            return account;
//        }


//        private AccountRequesModel MapRequestToDB(Account account)
//        {
//            var requestModel = new AccountRequesModel();
//            requestModel.Name = account.Name;
//            requestModel.LastName = account.LastName;
//            requestModel.Balance = account.Balance;
//            requestModel.City = account.City;

//            return requestModel;
//        }

//        private Account MapRequestToSet(Account res, AccountRequesModel account)
//        {
//            res.Name = account.Name;
//            res.LastName = account.LastName;
//            res.Balance = account.Balance;
//            res.City = account.City;
           
//            return res;
//        }

//        Task<ActionResult<List<Account>>> IAccountServices.GetAllAccounts()
//        {
//            throw new NotImplementedException();
//        }

//        Task IAccountServices.UpdateAccount(Guid id, Account account)
//        {
//            throw new NotImplementedException();
//        }

//        Task<Account> IAccountServices.AddAccounts(AccountRequesModel account)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Data.Models;
using WebApplication2.Services.Contraxts;

namespace WebApplication2.Services.Iplametation
{
    public class AccountService : IAccountServices
    {
        private readonly DataContext _context;

        public AccountService(DataContext context)
        {
            _context = context;
        }

        // Метод отримання всіх Акаунтів
        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await _context.Account.ToListAsync();
        }

        // Акаунт за ID
        public async Task<Account> GetAccountById(Guid id)
        {
            return await _context.Account.FindAsync(id);
        }

        // Створення нового акаунту
        public async Task CreateAccount(Account account)
        {
            _context.Account.Add(account);
            await _context.SaveChangesAsync();
        }

        //Редагування обновлення хз
        public async Task UpdateAccount(Account account)
        {
            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Видалення за ID
        public async Task DeleteAccount(Guid id)
        {
            var account = await _context.Account.FindAsync(id);
            if (account != null)
            {
                _context.Account.Remove(account);
                await _context.SaveChangesAsync();
            }
        }
    }
}

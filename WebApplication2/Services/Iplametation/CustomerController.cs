using WebApplication2.Data.Models;
using WebApplication2.Data;
using WebApplication2.Services.Contraxts;

namespace WebApplication2.Services.Iplametation
{
    public class CustomerService : ICustomerServices
    {
        private readonly DataContext _context;
        public CustomerService(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await _context.Customer.ToListAsync();
        }
        public async Task<Customer> GetCustomerById(Guid id)
        {
            return await _context.Customer.FindAsync(id);
        }
        public async Task CreateCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCustomer(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCustomer(Guid id)
        {
            var customer = await _context.Cards.FindAsync(id);
            if (customer != null)
            {
                _context.Cards.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}

using WebApplication2.Data.Models;

namespace WebApplication2.Services.Contraxts
{
    public interface ICustomerServices
    {
        Task CreateCustomer(Customer customer);
        Task<IEnumerable<Customer>> GetAllCustomer();
        Task<Customer> GetCustomerById(Guid id);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(Guid id);
    }
}

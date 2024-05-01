using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data.Models;
using WebApplication2.Model;
using WebApplication2.Models;

namespace WebApplication2.Controller.Services.Contracts
{
    public interface ICustomerServices
    {
        Task<ActionResult<List<Customer>>> GetAllCustomers();
        Task<CustomerRequesModel> GetCustomer(Guid id);
        Task<Customer> AddCustomer(CustomerRequesModel customer);
        Task<Guid> UpdateCustomer(Guid id, CustomerRequesModel requestModel);
        Task<Guid> DeleteCustomer(Guid id);
    }
}

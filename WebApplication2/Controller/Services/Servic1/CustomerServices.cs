using Microsoft.AspNetCore.Mvc;
using WebApplication2.Controller.Services.Contracts;
using WebApplication2.Data;
using WebApplication2.Model;
using WebApplication2.Models;

namespace WebApplication2.Controller.Services.Servic1
{
    public class CustomerServices : ICustomerServices
    {
        private readonly DataContext _context;

        public CustomerServices(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            var customers = await _context.Customer.ToListAsync();

            return customers;
        }


        public async Task<CustomerRequesModel> GetCustomer(Guid id)
        {
            var customer = await _context.Customer.FindAsync(id);

            if (customer == null)
            {
                return null;
            }
            var res = MapRequestToDB(customer);

            return res;
        }


        public async Task<Customer> AddCustomer(CustomerRequesModel customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            var res = MapRequestToCustomer(customer);

            _context.Customer.AddAsync(res);
            await _context.SaveChangesAsync();

            return res;
        }


        public async Task<Guid> DeleteCustomer(Guid id)
        {
            var account = await _context.Customer.FindAsync(id);
            if (account == null)
            {
                return Guid.Empty;
            }

            _context.Customer.Remove(account);
            await _context.SaveChangesAsync();

            return id;
        }


        public async Task<Guid> UpdateCustomer(Guid id, CustomerRequesModel requestModel)
        {
            var account = await _context.Customer.FindAsync(id);
            if (account == null)
            {
                return Guid.Empty;
            }
            account = MapRequestToSet(account, requestModel);
            _context.Customer.Update(account);
            await _context.SaveChangesAsync();

            return id;
        }


        private Customer MapRequestToCustomer(CustomerRequesModel requestModel)
        {
            var customer = new Customer();
            customer.Id = Guid.NewGuid();
            customer.CName = requestModel.Name;
            customer.CLName = requestModel.LastName;
            customer.Country = requestModel.Country;
            customer.CPhone = requestModel.Phone;
            customer.CEmail = requestModel.Email;
            return customer;
        }


        private CustomerRequesModel MapRequestToDB(Customer customer)
        {
            var requestModel = new CustomerRequesModel();
            requestModel.Name = customer.CName;
            requestModel.LastName = customer.CLName;
            requestModel.Country = customer.Country;
            requestModel.Phone = customer.CPhone;
            requestModel.Email = customer.CEmail;

            return requestModel;
        }

        private Customer MapRequestToSet(Customer res, CustomerRequesModel customer)
        {
            res.CName = customer.Name;
            res.CLName = customer.LastName;
            res.Country = customer.Country;
            res.CPhone = customer.Phone;
            res.CEmail = customer.Email;

            return res;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebApplication2.Controller.Services.Contracts;
using WebApplication2.Data;
using WebApplication2.Model;
using WebApplication2.Models;

namespace WebApplication2.Controller.Services.Servic1
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly DataContext _context;

        public EmployeeServices(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<Employee>>> GetAllEmployee()
        {
            var employee = await _context.Employee.ToListAsync();

            return employee;
        }


        public async Task<EmployeeRequesModel> GetEmployee(Guid id)
        {
            var employee = await _context.Employee.FindAsync(id);

            if (employee == null)
            {
                return null;
            }
            var res = MapRequestToDB(employee);

            return res;
        }


        public async Task<Employee> AddEmployee(EmployeeRequesModel employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            var res = MapRequestToEmployee(employee);

            _context.Employee.AddAsync(res);
            await _context.SaveChangesAsync();

            return res;
        }


        public async Task<Guid> DeleteEmployee(Guid id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return Guid.Empty;
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return id;
        }


        public async Task<Guid> UpdateEmployee(Guid id, EmployeeRequesModel requestModel)
        {
            var account = await _context.Employee.FindAsync(id);
            if (account == null)
            {
                return Guid.Empty;
            }
            account = MapRequestToSet(account, requestModel);
            _context.Employee.Update(account);
            await _context.SaveChangesAsync();

            return id;
        }


        private Employee MapRequestToEmployee(EmployeeRequesModel requestModel)
        {
            var employee = new Employee();
            employee.Id = Guid.NewGuid();
            employee.FirstName = requestModel.FirstName;
            employee.LastName = requestModel.LastName;
            employee.Country = requestModel.Country;
            employee.phone = requestModel.phone;
            return employee;
        }


        private EmployeeRequesModel MapRequestToDB(Employee employee)
        {
            var requestModel = new EmployeeRequesModel();
            requestModel.FirstName = employee.FirstName;
            requestModel.LastName = employee.LastName;
            requestModel.Country = employee.Country;
            requestModel.phone = employee.phone;
            return requestModel;
        }

        private Employee MapRequestToSet(Employee res, EmployeeRequesModel employee)
        {
            res.FirstName = employee.FirstName;
            res.LastName = employee.LastName;
            res.Country = employee.Country;
            res.phone = employee.phone;


            return res;
        }
    }
}
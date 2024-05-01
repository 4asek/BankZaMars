using WebApplication2.Data.Models;
using WebApplication2.Models;

namespace WebApplication2.Controller.Services.Contracts
{
    public interface IEmployeeServices
    {
        Task CreateEmployees(Employee employee);
        Task<IEnumerable<Employee>> GetAllEmloyee();
        Task<Employee> GetEmployeeById(Guid id);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(Guid id);
    }
}

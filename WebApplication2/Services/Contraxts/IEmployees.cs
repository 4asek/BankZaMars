using WebApplication2.Data.Models;

namespace WebApplication2.Services.Contraxts
{
    public interface IEmployees
    {
        Task CreateEmployees(Employee employee);
        Task<IEnumerable<Employee>> GetAllEmloyee();
        Task<Employee> GetEmployeeById(Guid id);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(Guid id);
    }
}

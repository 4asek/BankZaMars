using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data.Models;
using WebApplication2.Model;
using WebApplication2.Models;

namespace WebApplication2.Controller.Services.Contracts
{
    public interface IEmployeeServices
    {
        Task<ActionResult<List<Employee>>> GetAllEmployee();
        Task<EmployeeRequesModel> GetEmployee(Guid id);
        Task<Employee> AddEmployee(EmployeeRequesModel employee);
        Task<Guid> UpdateEmployee(Guid id, EmployeeRequesModel requestModel);
        Task<Guid> DeleteEmployee(Guid id);
    }
}

using System.ComponentModel.DataAnnotations;
using WebApplication2.Data.Models;

namespace WebApplication2.Models
{
    public class Employee
    {
        [Key] public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string phone { get; set; }
        public string Country { get; set; }
        public List<Account> Account { get; set; }
    }
}

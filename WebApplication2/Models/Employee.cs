using System.ComponentModel.DataAnnotations;

namespace WebApplication2.TableClass
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string phone { get; set; }
        public string Country { get; set; }
    }
}

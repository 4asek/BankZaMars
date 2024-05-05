using WebApplication2.Data.Models;

namespace WebApplication2.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string CName { get; set; }
        public string CLName { get; set; }
        public string Country { get; set; }
        public string CPhone { get; set; }
        public string CEmail { get; set; }
        public Account Account { get; set; }
        //public List<Account> Accounts { get; set; }
    }
}

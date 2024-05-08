namespace WebApplication2.Model
{
    public class AccountRequesModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double Balance { get; set; }
        public Guid CustomerID { get; set; }

        public Guid EmployeeID { get; set; }
    }
}

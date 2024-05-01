namespace WebApplication2.Model
{
    public class AccountRequesModel
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

        public Guid EmployeeID { get; set; }
        public Guid CustomerID { get; set; }
    }
}

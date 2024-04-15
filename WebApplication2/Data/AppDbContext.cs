using WebApplication2.Data.Models;

namespace WebApplication2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) 
        { 
        
        
        
        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }

    }
}

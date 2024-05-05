using WebApplication2.Data.Models;
using WebApplication2.Models;


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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>()
                .Property(c => c.Balance)
                .HasColumnType("decimal(18,2)");
            ///одна карта, багато транзакцій
            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CardID)
                      .IsRequired();

                entity.HasOne(e => e.Cards)
                      .WithMany(a => a.Transactions)
                      .HasForeignKey(e => e.AccountId)
                      .HasPrincipalKey(x => x.Id);
            });
            //один аккаунт, багато карт
            modelBuilder.Entity<Account>()
            .HasMany(a => a.Cards)
            .WithOne(c => c.Account)
            .HasForeignKey(c => c.AccountId);
            // Один обліковий запис на одного клієнта
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(c => c.CustomerId)
                      .IsRequired();

                entity.HasOne(e => e.Customer)
                      .WithOne(c => c.Account)
                      .HasForeignKey<Account>(e => e.CustomerId)
                      .HasPrincipalKey<Customer>(c => c.Id);
            });
            //один працівник, багато аккаунтів
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(c => c.EmployeeID).IsRequired();

                entity.HasOne(e => e.Employees)
                      .WithMany(c => c.Account)
                      .HasForeignKey(e => e.EmployeeID)
                      .HasPrincipalKey(c => c.Id);
            });
        }
    }
}

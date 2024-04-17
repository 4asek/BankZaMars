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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>()
                .Property(c => c.Balance)
                .HasColumnType("decimal(18,2)");
            //modelBuilder.Entity<Transactions>(entity =>
            //{
            //    entity.HasKey(e => e.Id);

            //    entity.Property(e => e.AccID)
            //          .IsRequired();

            //    entity.HasOne(e => e.Accounts)
            //          .WithMany(a => a.Transactions)
            //          .HasForeignKey(e => e.AccountId)
            //          .HasPrincipalKey(x => x.id);
            //});
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
        }
    }
}

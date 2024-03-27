using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebApplication2.TableClass;
using System;
using Microsoft.Extensions.Configuration; 

namespace WebApplication2.Models
{
    public class MyContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MyContext(DbContextOptions<MyContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<Card> Cards { get; set; } 
        public void AddCard(Card card)
        {
            Cards.Add(card);
            SaveChanges();
        }
        public DbSet<Transactions> Transactions { get; set; }
        public void AddTransaction(Transactions transaction)// Метод для додавання транзакції
        {
            Transactions.Add(transaction);
            SaveChanges();
        }
        public Transactions GetTransactionById(int id)// Отримати транзакцію за ID
        {
            return Transactions.Find(id);
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                
                var connectionString = _configuration.GetConnectionString("MyDatabaseConnection");
                var serverVersion = ServerVersion.Parse("8.0.28");
                optionsBuilder.UseMySql(connectionString, serverVersion);
            }
            catch (Exception ex)
            {
                
                throw; 
            }
        }
    }
}

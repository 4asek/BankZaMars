using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Data.Models;

namespace WebApplication2.Models
{
    public class Transactions
    {
        [Key]
        public Guid Id { get; set; }
        public Guid AccID { get; set; } // Змінено тип на Guid
        public DateTime TransactionDate { get; set; }
        public double Suma { get; set; }
        public bool readiness { get; set; } 
        //public virtual Account Accounts { get; set; }

        //[ForeignKey("Account")]
        //public Guid AccountId { get; set; } 
        public virtual Card Cards { get; set; }

        [ForeignKey("Account")]
        public Guid CardID { get; set; } 
    }
}// 

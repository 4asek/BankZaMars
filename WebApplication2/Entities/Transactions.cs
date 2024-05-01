using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Transactions
    {
        [Key]
        public Guid Id { get; set; }
        public Guid AccID { get; set; } // Змінено тип на Guid
        public Guid CardID { get; set; }
        public DateTime TransactionDate { get; set; }
        public double Suma { get; set; }
        public bool readiness { get; set; } // Це має бути властивість
        public virtual Accounts Accounts { get; set; }

        [ForeignKey("Account")]
        public Guid AccountId { get; set; } // Змінено тип на Guid
        public virtual Card Cards { get; set; }

        [ForeignKey("Account")]
        public Guid CardId { get; set; } // Змінено тип на Guid
    }
}// 

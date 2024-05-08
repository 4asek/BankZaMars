using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Data.Models;

namespace WebApplication2.Models
{
    public class Card
    {
        [Key]
        public Guid Id { get; set; }
        public int NumberCard { get; set; }
        public string CardName { get; set; }
        public int Pincode { get; set; }
        public DateTime Data { get; set; }
        public int CVV { get; set; }
        public decimal Balance { get; set; }
        public virtual Account Account { get; set; }

        [ForeignKey("Account")]
        public Guid AccountId { get; set; }
        public List<Transactions> Transactions { get; set; }

        public string AccLink { get; set; }
    }
}

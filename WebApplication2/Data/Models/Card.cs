using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Data.Models
{
    public class Card
    {
        [Key]
        public Guid id { get; set; }
        public int NumberCard { get; set; }
        public string CardName { get; set; }
        public int Pincode { get; set; }
        public DateTime DataDii { get; set; }
        public int CVV { get; set; }
        public double Balance { get; set; }
        public string AccLink { get; set; }
    }
}

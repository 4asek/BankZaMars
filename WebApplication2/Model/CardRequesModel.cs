namespace WebApplication2.Model
{
    public class CardRequesModel
    {
        public int NumberCard { get; set; }
        public string CardName { get; set; }
        public int Pincode { get; set; }
        public DateTime Data { get; set; }
        public int CVV { get; set; }
        public decimal Balance { get; set; }
        public Guid AccountId { get; set; }

    }
}

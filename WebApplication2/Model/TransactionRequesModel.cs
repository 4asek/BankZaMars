namespace WebApplication2.Model
{
    public class TransactionRequesModel
    {
        public DateTime TransactionDate { get; set; }
        public double Suma { get; set; }
        public bool readiness { get; set; }
        public Guid CardID { get; set; }
    }
}

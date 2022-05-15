namespace MicroRabbit.Banking.Domain.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountType { get; set; } = String.Empty;

        public decimal AccountBalance { get; set; }
    }
}

namespace FinancialDocumentApi.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }

        public double Amount { get; set; }

        public DateOnly Date {  get; set; }

        public string Description { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;
    }
}

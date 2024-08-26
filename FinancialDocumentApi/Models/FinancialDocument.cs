namespace FinancialDocumentApi.Models
{
    public class FinancialDocument
    {
        public Guid TenantId { get; set; }
        public Guid DocumentId { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string Currency { get; set; } = string.Empty;
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

    }
}

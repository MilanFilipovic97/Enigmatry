namespace FinancialDocumentApi.Models
{
    public class Document
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public Guid TenantId { get; set; }

        public Tenant Tenant { get; set; } = new Tenant(); 

        public Guid CLientId { get; set; }

        public Client Client { get; set; } = new Client();
    }
}

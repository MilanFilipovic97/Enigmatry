namespace FinancialDocumentApi.Models
{
    public class WhitelistClientTenant
    {
        public Guid Id { get; set; }

        public Guid TenantId { get; set; }

        public Guid ClientId { get; set; }

        public bool IsWhiteListed { get; set; } 

        public Tenant Tenant { get; set; } = new Tenant();

        public Client Client { get; set; } = new Client();
    }
}

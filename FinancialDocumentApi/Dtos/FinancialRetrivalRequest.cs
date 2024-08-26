namespace FinancialDocumentApi.Dtos
{
    public class FinancialRetrivalRequest
    {
        public string ProductCode { get; set; } = string.Empty;

        public Guid TenantId { get; set; }

        public Guid DocumentId { get; set; }
    }
}

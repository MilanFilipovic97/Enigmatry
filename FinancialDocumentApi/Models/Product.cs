namespace FinancialDocumentApi.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string ProductCode { get; set; } = string.Empty;

        public bool IsSupported { get; set; }

    }
}

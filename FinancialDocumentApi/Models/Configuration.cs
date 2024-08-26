namespace FinancialDocumentApi.Models
{
    public class Configuration
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }

        public List<FieldConfiguration> FieldConfigurations { get; set; } = new List<FieldConfiguration>();
    }
}

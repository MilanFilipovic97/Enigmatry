namespace FinancialDocumentApi.Models
{
    public class FieldConfiguration
    {
        public string FieldName { get; set; } = string.Empty;
        public AnonymizationType AnonymizationType { get; set; }
    }

    public enum AnonymizationType
    {
        Mask,
        Hash,
        Unchanged
    }
}

namespace FinancialDocumentApi.Models
{
    public class Client
    {
        public Guid Id { get; set; }

        public string ClientVat {  get; set; } = string.Empty;

        public string RegistrationNumber {  get; set; } = string.Empty;

        public CompanyTypeEnum CompanyType { get; set; }

        public bool IsWhitelisted { get; set; }
    }
    public enum CompanyTypeEnum
    {
        Small,
        Medium,
        Large
    }
}

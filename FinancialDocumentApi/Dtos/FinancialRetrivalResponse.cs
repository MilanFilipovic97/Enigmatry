using FinancialDocumentApi.Models;

namespace FinancialDocumentApi.Dtos
{
    public class FinancialRetrivalResponse
    {
        public FinancialDocument FinancialDocument { get; set; } = new FinancialDocument();
        public CompanyDto Company { get; set; } = new CompanyDto();

    }

    public class CompanyDto
    {
        public string RegistrationNumber { get; set; } = string.Empty;
        public string CompanyType { get; set; } = string.Empty;
    }
}

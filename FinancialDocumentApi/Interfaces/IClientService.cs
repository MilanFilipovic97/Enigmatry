using FinancialDocumentApi.Models;

namespace FinancialDocumentApi.Interfaces
{
    public interface IClientService
    {
        (Guid clientId, string clientVat) GetClientId(Guid tenantId, Guid documentId);
        bool IsWhiteListed(Guid tenantId, Guid clientId);

        (string registrationNumber, CompanyTypeEnum companyType) GetCompanyData(string clientVat);
    }
}

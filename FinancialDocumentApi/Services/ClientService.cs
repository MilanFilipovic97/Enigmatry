using FinancialDocumentApi.Data;
using FinancialDocumentApi.Interfaces;
using FinancialDocumentApi.Models;
using System.Data;

namespace FinancialDocumentApi.Services
{
    public class ClientService : IClientService
    {
        public (Guid clientId, string clientVat) GetClientId(Guid tenantId, Guid documentId)
        {
            Guid clientId = DataStore.Documents
                .Where(x => x.TenantId == tenantId && x.Id == documentId)
                .Select(x => x.CLientId)
                .FirstOrDefault();

            string clientVat = DataStore.Clients
                .Where(x => x.Id == clientId)
                .Select(x => x.ClientVat)
                .FirstOrDefault() ?? string.Empty;

            return (clientId, clientVat);
        }

        public bool IsWhiteListed(Guid tenantId, Guid clientId)
        {
            return DataStore.WhitelistClientsTenants
                .Where(x => x.TenantId == tenantId && x.ClientId == clientId)
                .Select(x => x.IsWhiteListed)
                .FirstOrDefault();
        }

        public (string registrationNumber, CompanyTypeEnum companyType) GetCompanyData(string clientVat)
        {
            return DataStore.Clients
                .Where(x => x.ClientVat == clientVat)
                .Select(x => (x.RegistrationNumber, x.CompanyType))
                .FirstOrDefault();
        }
    }
}

using FinancialDocumentApi.Data;
using FinancialDocumentApi.Interfaces;

namespace FinancialDocumentApi.Services
{
    public class TenantService : ITenantService
    {
        public bool IsWhiteListed(Guid TenantId)
        {
            return DataStore.Tenants
                .Where(x => x.Id == TenantId)
                .Select(x => x.IsWhiteListed)
                .FirstOrDefault();
        }
    }
}

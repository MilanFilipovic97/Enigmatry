namespace FinancialDocumentApi.Interfaces
{
    public interface ITenantService
    {
        bool IsWhiteListed(Guid id);
    }
}

using FinancialDocumentApi.Models;

namespace FinancialDocumentApi.Interfaces
{
    public interface IFinancialDocumentService
    {
        FinancialDocument GetFinancialDocument(Guid tenantId, Guid documentId);

        FinancialDocument AnonymizeFinancialDocument(FinancialDocument document, string productCode);
    }
}

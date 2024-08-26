using FinancialDocumentApi.Data;
using FinancialDocumentApi.Interfaces;
using FinancialDocumentApi.Models;
using System.Reflection;

namespace FinancialDocumentApi.Services
{
    public class FinancialDocumentService : IFinancialDocumentService
    {
        public FinancialDocument GetFinancialDocument(Guid tenantId, Guid documentId)
        {
            var document = DataStore.FinancialDocuments
                .Where(x => x.TenantId == tenantId && x.DocumentId == documentId)
                .FirstOrDefault() ?? new FinancialDocument();

            return document;
        }

        public FinancialDocument AnonymizeFinancialDocument(FinancialDocument document, string productCode)
        {
            var productConfiguration = DataStore.Products
                .Where(x => x.ProductCode == productCode)
                .Select(x => x.Configuration)
                .FirstOrDefault() ?? new Configuration();

            var fieldToPropertyMapping = new Dictionary<string, string>
            {
                { "account_number", nameof(FinancialDocument.AccountNumber) },
                { "balance", nameof(FinancialDocument.Balance) },
                { "currency", nameof(FinancialDocument.Currency) },
                { "transaction_id", nameof(Transaction.Id) },
                { "description", nameof(Transaction.Description) }
            };

            foreach (var fieldConfig in productConfiguration.FieldConfigurations)
            {
                if (fieldToPropertyMapping.TryGetValue(fieldConfig.FieldName, out var propertyName))
                {
                    ApplyAnonymization(document, propertyName, fieldConfig.AnonymizationType);
                }
            }

            return document;
        }


        public void ApplyAnonymization(FinancialDocument document, string propertyName, AnonymizationType anonymizationType)
        {
            var propertyInfo = document.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (propertyInfo != null && propertyInfo.CanWrite)
            {
                ApplyAnonymizationToProperty(document, propertyInfo, anonymizationType);
            }
            else
            {
                foreach (var transaction in document.Transactions)
                {
                    var transactionPropertyInfo = transaction.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                    if (transactionPropertyInfo != null && transactionPropertyInfo.CanWrite)
                    {
                        ApplyAnonymizationToProperty(transaction, transactionPropertyInfo, anonymizationType);
                    }
                }
            }
        }

        private void ApplyAnonymizationToProperty(object targetObject, PropertyInfo propertyInfo, AnonymizationType anonymizationType)
        {
            var propertyType = propertyInfo.PropertyType;

            switch (anonymizationType)
            {
                case AnonymizationType.Mask:
                    if (propertyType == typeof(string))
                    {
                        propertyInfo.SetValue(targetObject, "#####");
                    }
                    else if (propertyType == typeof(Guid))
                    {
                        propertyInfo.SetValue(targetObject, Guid.Empty);
                    }
                    else if (propertyType == typeof(decimal) || propertyType == typeof(double))
                    {
                        propertyInfo.SetValue(targetObject, 0);
                    }
                    break;
                case AnonymizationType.Hash:
                    var currentValue = propertyInfo.GetValue(targetObject)?.ToString() ?? string.Empty;
                    propertyInfo.SetValue(targetObject, Hash(currentValue));
                    break;
                case AnonymizationType.Unchanged:
                    break;
            }
        }

        private string Hash(string input)
        {
            return input.GetHashCode().ToString();
        }
    }
}

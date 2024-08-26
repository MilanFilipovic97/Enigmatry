using FinancialDocumentApi.Data;
using FinancialDocumentApi.Interfaces;

namespace FinancialDocumentApi.Services
{
    public class ProductService : IProductService
    {
        public bool IsProductSupported(string productCode)
        {
            return DataStore.Products
                .Where(x => x.ProductCode == productCode)
                .Select(x => x.IsSupported)
                .FirstOrDefault();
        }
    }
}

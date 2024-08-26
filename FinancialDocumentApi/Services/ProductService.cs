using FinancialDocumentApi.Data;
using FinancialDocumentApi.Interfaces;
using FinancialDocumentApi.Models;

namespace FinancialDocumentApi.Services
{
    public class ProductService : IProductService
    {
        public bool IsProductSupported(string productCode)
        {
            var productList = DataStore.Products.ToList();

            return productList
                .Where(x => x.ProductCode == productCode)
                .Select(x => x.IsSupported)
                .FirstOrDefault();
        }
    }
}

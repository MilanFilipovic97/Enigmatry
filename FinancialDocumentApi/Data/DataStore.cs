using FinancialDocumentApi.Models;

namespace FinancialDocumentApi.Data
{
    public static class DataStore
    {
        public static List<Product> Products = new List<Product>
        {
            new Product
            {
                ProductCode = "Product A",
                Id = new Guid("721bbf48-8274-4d82-a4fe-6e6ec371d468"),
                IsSupported = true
            },
            new Product
            {
                ProductCode = "Product B",
                Id = new Guid("f5177293-254b-4fc9-b676-82070abb7d74"),
                IsSupported = true
            },
            new Product
            {
                ProductCode = "Product C",
                Id = new Guid("8dc840c5-3eb1-49bc-bb9c-15f412217ef3"),
                IsSupported = false
            },
            new Product
            {
                ProductCode = "Product D",
                Id = new Guid("797dc1d8-9e1f-4ed1-bcde-82b7a4053f3a"),
                IsSupported = false
            }
        };
    }
}

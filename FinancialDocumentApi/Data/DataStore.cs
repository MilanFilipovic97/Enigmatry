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
                IsSupported = true,
                Configuration =
                {
                    Id = new Guid("a2bf31d5-1a00-4e74-a914-593da427e9eb"),
                    ProductId = new Guid("721bbf48-8274-4d82-a4fe-6e6ec371d468"),
                    FieldConfigurations = new List<FieldConfiguration>
                    {
                        new FieldConfiguration { FieldName = "account_number", AnonymizationType = AnonymizationType.Hash },
                        new FieldConfiguration { FieldName = "balance", AnonymizationType = AnonymizationType.Unchanged },
                        new FieldConfiguration { FieldName = "currency", AnonymizationType = AnonymizationType.Unchanged },
                        new FieldConfiguration { FieldName = "transaction_id", AnonymizationType = AnonymizationType.Mask },
                        new FieldConfiguration { FieldName = "description", AnonymizationType = AnonymizationType.Mask }
                    }
                }
            },
            new Product
            {
                ProductCode = "Product B",
                Id = new Guid("f5177293-254b-4fc9-b676-82070abb7d74"),
                IsSupported = true,
                Configuration =
                {
                    Id = new Guid("b38ff9be-e858-4c43-bbcf-931776956b20"),
                    ProductId = new Guid("f5177293-254b-4fc9-b676-82070abb7d74"),
                    FieldConfigurations = new List<FieldConfiguration>
                    {
                        new FieldConfiguration { FieldName = "account_number", AnonymizationType = AnonymizationType.Hash },
                        new FieldConfiguration { FieldName = "balance", AnonymizationType = AnonymizationType.Unchanged },
                        new FieldConfiguration { FieldName = "currency", AnonymizationType = AnonymizationType.Unchanged },
                        new FieldConfiguration { FieldName = "transaction_id", AnonymizationType = AnonymizationType.Mask },
                        new FieldConfiguration { FieldName = "description", AnonymizationType = AnonymizationType.Mask }
                    }
                }
            },
            new Product
            {
                ProductCode = "Product C",
                Id = new Guid("8dc840c5-3eb1-49bc-bb9c-15f412217ef3"),
                IsSupported = false,
                Configuration =
                {
                    Id = new Guid("12340b17-ec42-44ab-baed-5cb35f3de2c2"),
                    ProductId = new Guid("8dc840c5-3eb1-49bc-bb9c-15f412217ef3"),
                    FieldConfigurations = new List<FieldConfiguration>
                    {
                        new FieldConfiguration { FieldName = "account_number", AnonymizationType = AnonymizationType.Hash },
                        new FieldConfiguration { FieldName = "balance", AnonymizationType = AnonymizationType.Unchanged },
                        new FieldConfiguration { FieldName = "currency", AnonymizationType = AnonymizationType.Unchanged },
                        new FieldConfiguration { FieldName = "transaction_id", AnonymizationType = AnonymizationType.Mask },
                        new FieldConfiguration { FieldName = "description", AnonymizationType = AnonymizationType.Mask }
                    }
                }
            },
            new Product
            {
                ProductCode = "Product D",
                Id = new Guid("797dc1d8-9e1f-4ed1-bcde-82b7a4053f3a"),
                IsSupported = false,
                Configuration =
                {
                    Id = new Guid("000b0ef2-f850-40ff-8b09-f4985f409202"),
                    ProductId = new Guid("797dc1d8-9e1f-4ed1-bcde-82b7a4053f3a"),
                    FieldConfigurations = new List<FieldConfiguration>
                    {
                        new FieldConfiguration { FieldName = "account_number", AnonymizationType = AnonymizationType.Hash },
                        new FieldConfiguration { FieldName = "balance", AnonymizationType = AnonymizationType.Unchanged },
                        new FieldConfiguration { FieldName = "currency", AnonymizationType = AnonymizationType.Unchanged },
                        new FieldConfiguration { FieldName = "transaction_id", AnonymizationType = AnonymizationType.Mask },
                        new FieldConfiguration { FieldName = "description", AnonymizationType = AnonymizationType.Mask }
                    }
                }
            }
        };

        public static List<Tenant> Tenants = new List<Tenant>
        {
            new Tenant
            {
                Id = new Guid("952f964b-fff5-488b-9101-1fef49d5dc4b"),
                Name = "Test Tenant 1",
                IsWhiteListed = true
            },
            new Tenant
            {
                Id = new Guid("55bc1fdc-0bdd-4f34-97d9-7169a8e3370c"),
                Name = "Test Tenant 2",
                IsWhiteListed = false
            },
            new Tenant
            {
                Id = new Guid("37fffe24-735d-486f-bca9-cf6eec187aee"),
                Name = "Test Tenant 3",
                IsWhiteListed = true
            }
        };

        public static List<Client> Clients = new List<Client>
        {
            new Client
            {
                Id= new Guid("abab95e5-8557-4ad2-80a1-1eb66eea41f7"),
                ClientVat = "123456",
                RegistrationNumber = "registration 1",
                CompanyType = CompanyTypeEnum.Large,
                IsWhitelisted = true
            },
            new Client
            {
                Id= new Guid("e5e54132-2c05-463c-afe2-5834cb437e06"),
                ClientVat = "12211",
                RegistrationNumber = "registration 2",
                CompanyType = CompanyTypeEnum.Medium,
                IsWhitelisted = true
            },
            new Client
            {
                Id= new Guid("745696d8-47d5-4922-b173-7e24d144bf38"),
                ClientVat = "23232",
                RegistrationNumber = "registration 3",
                CompanyType = CompanyTypeEnum.Small,
                IsWhitelisted = false
            },
        };
        
        public static List<Document> Documents = new List<Document>
        {
            new Document
            {
                Id = new Guid("27d8fc2b-34e0-42ae-9dd6-91314932f645"),
                Title = "Document 1",
                TenantId = Tenants[0].Id,
                Tenant = Tenants[0],
                CLientId = Clients[0].Id,
                Client = Clients[0]
            },
            new Document
            {
                Id = new Guid("b3587913-48bc-4ce0-89a1-f3c84f82f244"),
                Title = "Document 2",
                TenantId = Tenants[1].Id,
                Tenant = Tenants[1],
                CLientId = Clients[1].Id,
                Client = Clients[1]
            },
            new Document
            {
                Id = new Guid("cb04bf9a-4f31-4f58-ac30-cde6895cfb43"),
                Title = "Document 3",
                TenantId = Tenants[2].Id,
                Tenant = Tenants[2],
                CLientId = Clients[2].Id,
                Client = Clients[2]
            },
        };

        public static List<WhitelistClientTenant> WhitelistClientsTenants = new List<WhitelistClientTenant>
        {
            new WhitelistClientTenant
            {
                Id= new Guid("dcb741b3-e37a-42d6-903b-ff1ecbe238af"),
                Client= Clients[0],
                ClientId = Clients[0].Id,
                Tenant= Tenants[0],
                TenantId= Tenants[0].Id,
                IsWhiteListed= true,
            },
            new WhitelistClientTenant
            {
                Id= new Guid("c3eb9143-1638-416d-a3ec-8676d410da60"),
                Client= Clients[1],
                ClientId = Clients[1].Id,
                Tenant= Tenants[1],
                TenantId= Tenants[1].Id,
                IsWhiteListed= true,
            },
            new WhitelistClientTenant
            {
                Id= new Guid("7ac5281f-7cf2-4ca5-ba14-bcecab2413c6"),
                Client= Clients[2],
                ClientId = Clients[2].Id,
                Tenant= Tenants[2],
                TenantId= Tenants[2].Id,
                IsWhiteListed= true,
            },
        };

        public static List<FinancialDocument> FinancialDocuments = new List<FinancialDocument>
        {
            new FinancialDocument
            {
                AccountNumber = "1111122",
                Balance =111,
                Currency = "EUR",
                DocumentId = Documents[0].Id,
                TenantId = Tenants[0].Id,
                Transactions =
                {
                    new Transaction
                    {
                        Id = new Guid("c11b4f2e-a61d-4e0b-87fa-c9152607a354"),
                        Amount = 6.58,
                        Date = new DateOnly(2024,1,20),
                        Category = "Food and dining",
                        Description = "Grocery shopping"
                    },
                    new Transaction
                    {
                        Id = new Guid("836df98e-d5b4-4988-b1eb-840085719231"),
                        Amount = 16.58,
                        Date = new DateOnly(2024,5,20),
                        Category = "Food and dining",
                        Description = "Grocery shopping"
                    },
                    new Transaction
                    {
                        Id = new Guid("fe4b2d27-7da0-4140-8ed7-9ef7dd2eba53"),
                        Amount = 56.78,
                        Date = new DateOnly(2024,10,21),
                        Category = "Utilities",
                        Description = "Gas station"
                    }
                }
            }
        };
    }
}

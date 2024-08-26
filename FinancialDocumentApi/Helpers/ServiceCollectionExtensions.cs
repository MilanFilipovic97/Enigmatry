using FinancialDocumentApi.Interfaces;
using FinancialDocumentApi.Services;

namespace FinancialDocumentApi.Helpers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IFinancialDocumentService, FinancialDocumentService>();

            return services;
        }
    }
}

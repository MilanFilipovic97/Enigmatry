using FinancialDocumentApi.Dtos;
using FinancialDocumentApi.Interfaces;
using FinancialDocumentApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Reflection.Metadata;

namespace FinancialDocumentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancialDocumentController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ITenantService _tenantService;
        private readonly IClientService _clientService;
        private readonly IFinancialDocumentService _financialDocumentService;
        
        public FinancialDocumentController(
            IProductService productService,
            ITenantService tenantService,
            IClientService clientService,
            IFinancialDocumentService financialDocumentService)
        {
            _productService = productService;
            _tenantService = tenantService;
            _clientService = clientService;
            _financialDocumentService = financialDocumentService;
        }
        
        [HttpPost]
        public ActionResult<FinancialRetrivalResponse> GetFinancialDocument(FinancialRetrivalRequest request)
        {
            if (!_productService.IsProductSupported(request.ProductCode))
            {
                return StatusCode(403, "This product doesn't exist.");
            }

            if (!_tenantService.IsWhiteListed(request.TenantId))
            {
                return StatusCode(403, "This tenant is not whitelisted.");
            }

            (Guid clientId, string clientVat) = _clientService.GetClientId(request.TenantId, request.DocumentId);
            
            if(!_clientService.IsWhiteListed(request.TenantId, clientId))
            {
                return StatusCode(403, "This client is not whitelisted.");
            }

            (string registrationNumber, CompanyTypeEnum companyType) = _clientService.GetCompanyData(clientVat);

            if (companyType == CompanyTypeEnum.Small)
            {
                return StatusCode(403, "Company is small.");
            }
            
            var financialDocument = _financialDocumentService.GetFinancialDocument(request.TenantId, request.DocumentId);

            var anonymizedDocument = _financialDocumentService.AnonymizeFinancialDocument(financialDocument, request.ProductCode);


            FinancialRetrivalResponse financialRetrivalResponse = new FinancialRetrivalResponse
            {
                FinancialDocument = anonymizedDocument,
                Company =
                {
                    RegistrationNumber = registrationNumber,
                    CompanyType = companyType.ToString()
                }
            };

            return Ok(financialRetrivalResponse);

        }
    }
}

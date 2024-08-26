using FinancialDocumentApi.Dtos;
using FinancialDocumentApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinancialDocumentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancialDocumentController : ControllerBase
    {
        private readonly IProductService _productService;
        
        public FinancialDocumentController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpPost]
        public IActionResult GetFinancialDocument(FinancialRetrivalRequest request)
        {
            if (!_productService.IsProductSupported(request.ProductCode))
            {
                return StatusCode(403, "This product doesn't exist");
            }

            return Ok();
        }
    }
}

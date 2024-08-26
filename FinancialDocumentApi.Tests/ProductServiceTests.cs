
using FinancialDocumentApi.Interfaces;
using FinancialDocumentApi.Services;

namespace FinancialDocumentApi.Tests
{
    [TestClass]
    public class ProductServiceTests
    {
        private IProductService _productService;


        [TestInitialize]
        public void Setup()
        {
            _productService = new ProductService();
        }

        [TestMethod]
        public void ProductExists()
        {
            string productName = "Product A";
            bool isSupported = _productService.IsProductSupported(productName);
            Assert.IsTrue(isSupported);
        }

        [TestMethod]
        public void ProductNotExists()
        {
            string productName = "Product E";
            bool isSupported = _productService.IsProductSupported(productName);
            Assert.IsFalse(isSupported);
        }
    }
}

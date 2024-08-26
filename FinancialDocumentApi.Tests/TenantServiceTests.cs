using FinancialDocumentApi.Interfaces;
using FinancialDocumentApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialDocumentApi.Tests
{
    [TestClass]
    public  class TenantServiceTests
    {
        private ITenantService _tenantService;


        [TestInitialize]
        public void Setup()
        {
            _tenantService = new TenantService();
        }

        [TestMethod]
        public void TenantNotWhitelisted()
        {
            bool isSupported = _tenantService.IsWhiteListed(new Guid("55bc1fdc-0bdd-4f34-97d9-7169a8e3370c"));
            Assert.IsFalse(isSupported);
        }
    }
}

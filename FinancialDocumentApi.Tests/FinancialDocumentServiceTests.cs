using FinancialDocumentApi.Interfaces;
using FinancialDocumentApi.Models;
using FinancialDocumentApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinancialDocumentApi.Tests
{
    [TestClass]
    public class FinancialDocumentServiceTests
    {
        private IFinancialDocumentService _financialService;
        private FinancialDocument _document;

        [TestInitialize]
        public void Setup()
        {
            _financialService = new FinancialDocumentService();

            // Create a sample FinancialDocument object for testing
            _document = new FinancialDocument
            {
                TenantId = Guid.NewGuid(),
                DocumentId = Guid.NewGuid(),
                AccountNumber = "1234567890",
                Balance = 1000.50m,
                Currency = "USD",
                Transactions = new List<Transaction>
                {
                    new Transaction
                    {
                        Id = Guid.NewGuid(),
                        Amount = 100.00,
                        Description = "Initial transaction",
                        Category = "Category1"
                    },
                    new Transaction
                    {
                        Id = Guid.NewGuid(),
                        Amount = 200.00,
                        Description = "Second transaction",
                        Category = "Category2"
                    }
                }
            };
        }

        [TestMethod]
        public void FinancialDocumentGenerated()
        {
            var financialDocument = _financialService.GetFinancialDocument(
                new Guid("952f964b-fff5-488b-9101-1fef49d5dc4b"),
                new Guid("27d8fc2b-34e0-42ae-9dd6-91314932f645"));
            
            Assert.IsNotNull(financialDocument);
        }

        [TestMethod]
        public void FinancialDocumentGenerationDoesntFailWithBadData()
        {
            var financialDocument = _financialService.GetFinancialDocument(
                new Guid("22222222-fff5-488b-9101-1fef49d5dc4b"),
                new Guid("11111111-fff5-488b-9101-1fef49d5dc4b"));

            Assert.IsNotNull(financialDocument);
        }

        [TestMethod]
        public void AnonymizeFinancialDocument_ShouldMaskTransactionDescription()
        {
            string productCode = "Product B";

            var anonymizedDocument = _financialService.AnonymizeFinancialDocument(_document, productCode);

            foreach (var transaction in anonymizedDocument.Transactions)
            {
                Assert.AreEqual("#####", transaction.Description, "Transaction Description was not masked correctly.");
            }
        }
    }
}

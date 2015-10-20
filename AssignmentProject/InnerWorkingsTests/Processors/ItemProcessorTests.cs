using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InnerWorkings.Processors.Tests
{
    [TestClass()]
    public class ItemProcessorTests
    {
        [TestMethod()]
        public void CalculatePriceTest_ShouldOmmitTaxWhenTaxFree()
        {
            var item = new Item(true)
            {
                Name = "Letter",
                Price = (float) 100.0
            };

            Assert.AreEqual(111, new ItemProcessor().CalculatePrice(item, 11, 5));
        }

        [TestMethod()]
        public void CalculatePriceTest_ShouldIncludeTaxAtDefault()
        {
            var item = new Item
            {
                Name = "Letter",
                Price = (float) 100.0
            };

            Assert.AreEqual(116, new ItemProcessor().CalculatePrice(item, 11, 5));
        }
    }
}
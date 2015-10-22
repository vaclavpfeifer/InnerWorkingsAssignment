using InnerWorkings.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InnerWorkings.Processors.Tests
{
    [TestClass()]
    public class ItemProcessorTests
    {
        [TestMethod()]
        public void CalculatePrice_ShouldOmmitTaxWhenTaxFree()
        {
            var item = new Item
            {
                IsTaxFree = true,
                Name = "Letter",
                Price = (double) 100.0
            };

            Assert.AreEqual(111, new ItemPriceCalculator().CalculatePrice(item, 11, 5));
        }

        [TestMethod()]
        public void CalculatePrice_ShouldIncludeTaxAtDefault()
        {
            var item = new Item
            {
                Name = "Letter",
                Price = (double) 100.0
            };

            Assert.AreEqual(116, new ItemPriceCalculator().CalculatePrice(item, 11, 5));
        }

        [TestMethod()]
        public void CalculatePrice_ShouldRoundToNearestCent()
        {
            Assert.AreEqual(125.56, new ItemPriceCalculator().CalculatePrice(new Item() {Price = 125.555}, 0, 0));
        }

        [TestMethod()]
        public void CalculateFinalSum_ShouldSumAndRoundToNearestEven()
        {
            Assert.AreEqual(6.6, new ItemPriceCalculator().CalculateFinalSum(new double[] {1.1, 2.2, 3.3}));
            Assert.AreEqual(1.26, new ItemPriceCalculator().CalculateFinalSum(new double[] { 1.255 }));
            Assert.AreEqual(2.26, new ItemPriceCalculator().CalculateFinalSum(new double[] { 2.265 }));
            Assert.AreEqual(3.26, new ItemPriceCalculator().CalculateFinalSum(new double[] { 3.266 }));
            Assert.AreEqual(45.28, new ItemPriceCalculator().CalculateFinalSum(new double[] { 45.2701 }));
            Assert.AreEqual(4.28, new ItemPriceCalculator().CalculateFinalSum(new double[] { 4.27 }));
            Assert.AreEqual(5.28, new ItemPriceCalculator().CalculateFinalSum(new double[] { 5.275 }));
            Assert.AreEqual(7.26, new ItemPriceCalculator().CalculateFinalSum(new double[] { 7.26 }));
        }
    }
}
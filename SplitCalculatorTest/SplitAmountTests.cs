using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SplitClassLibrary;
namespace SplitCalculatorTest
{
    [TestClass]
    public class SplitAmountTests
    {
        [TestMethod]
        public void SplitAmount_WithTotalAmountAndPeople_ReturnsCorrectAmount()
        {
            var result = SplitCalculator.SplitAmount(200m, 4);
            Assert.AreEqual(50m, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SplitAmount_ZeroPeople_ThrowsArgumentException()
        {
            SplitCalculator.SplitAmount(200m, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SplitAmount_NegativePeople_ThrowsArgumentException()
        {
            SplitCalculator.SplitAmount(200m, -1);
        }

        [TestClass]
        public class CalculateTipsTests
        {
            [TestMethod]
            public void CalculateTips_SimpleValues_CalculatesCorrectly()
            {
                var mealCosts = new Dictionary<string, decimal> { { "Alice", 120m }, { "Bob", 80m } };
                var result = BillCalculator.CalculateTips(mealCosts, 10);
                Assert.AreEqual(12m, result["Alice"]);
                Assert.AreEqual(8m, result["Bob"]);
            }

            [TestMethod]
            public void CalculateTips_RoundedValues_CalculatesCorrectly()
            {
                var mealCosts = new Dictionary<string, decimal> { { "Alice", 123.99m }, { "Bob", 78.01m } };
                var result = BillCalculator.CalculateTips(mealCosts, 15);
                Assert.AreEqual(18.60m, result["Alice"]);
                Assert.AreEqual(11.70m, result["Bob"]);
            }

            [TestMethod]
            public void CalculateTips_ZeroTip_ReturnsZero()
            {
                var mealCosts = new Dictionary<string, decimal> { { "Alice", 120m }, { "Bob", 80m } };
                var result = BillCalculator.CalculateTips(mealCosts, 0);
                Assert.AreEqual(0m, result["Alice"]);
                Assert.AreEqual(0m, result["Bob"]);
            }
        }
}

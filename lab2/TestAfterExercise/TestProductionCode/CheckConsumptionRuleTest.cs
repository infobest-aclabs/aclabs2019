using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductionCode;

namespace TestProductionCode
{
    [TestClass]
    public class CheckConsumptionRuleTest
    {
        [ExpectedException(typeof(NotImplementedException))]
        [TestMethod]
        public void TestMethod1()
        {
            var ruleChecker = new CheckConsumptionRule();
            var readingValue = new DeviceReadingValueDto();
            object[] args = { 0, 0 };
            ruleChecker.ValidateRule(readingValue, args);

            //Assert.AreEqual(1,1);
            //var ruleMock = new Mock<IRule>(); //https://github.com/Moq/moq4/wiki/Quickstart
        }
    }
}

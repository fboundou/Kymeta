using System;
using KymetaCodingTest.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Timer.Test
{
    [TestClass]
    public class TimerTest
    {
        Helper helper;

        [TestInitialize]
        public void SetUp()
        {
            helper = new Helper();
        }

        [TestMethod]
        public void ConvertStringToNumber_WhenCalled_ShouldReturnAnIntConversionSucceeded()
        {
            var result = helper.ConvertStringToNumber("123");
            int actual = 123;
            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        public void ConvertStringToNumber_WhenCalled_ShouldReturnMinusOneConversionFailed()
        {
            var result = helper.ConvertStringToNumber("abc");
            int actual = -1;
            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        public void CheckForNumericValue_WhenCalled_ShouldReturnTrueIfTheValueIsNumberic()
        {
            var help = new Helper();
            var result = help.IsNumeric("30");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckForNumericValue_WhenCalled_ShouldReturnFalseIfTheValueIsNotNumberic()
        {
            var help = new Helper();
            var result = help.IsNumeric("test");
            Assert.IsFalse(result);
        }
    }
}

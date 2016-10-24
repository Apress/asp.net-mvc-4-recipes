using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ch9.R2.Calc;

namespace Ch9.R2.Calc.Tests
{
    [TestClass]
    public class CalculatorCoreTests
    {

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Add_NegitiveValue_ThrowsInvalidOperationException()
        {
            CalculatorCore calc = new CalculatorCore();
            calc.Add(5, 5, 5, 5, -5);
        }

        [TestMethod]
        public void Add_NoValues_ReturnsZero()
        {
            CalculatorCore calc = new CalculatorCore();
            double expected = 0;
            double actual = calc.Add();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add__Five5s_Returns25()
        {
            CalculatorCore calc = new CalculatorCore();
            double expected = 0;
            double actual = calc.Add(5, 5, 5, 5, 5);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add__ValuesContainNaN_ReturnsZero()
        {
            CalculatorCore calc = new CalculatorCore();
            double expected = 0;
            double actual = calc.Add(float.NaN, 5 );
            Assert.AreEqual(expected, actual);
        }
    }
}

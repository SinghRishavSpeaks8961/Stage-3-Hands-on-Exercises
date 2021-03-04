using System;
using CalcLibrary;
using NUnit.Framework;

namespace CalcLibraryTestProject
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator _calc;

        [SetUp]
        public void SetUp()
        {
            _calc = new SimpleCalculator();
        }

        [Test]
        [TestCase(1, 2, 3)]
        public void Addition_WhenCalled_ShouldReturnTheSumOfArguments(double a, double b, double expected)
        {
            var result = _calc.Addition(a, b);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(1, 2, -1)]
        [TestCase(2, 1, 1)]
        [TestCase(1, 1, 0)]
        public void Substraction_WhenCalled_ShouldReturnTheDifferenceOfArguments(double a, double b, double expected)
        {
            var result = _calc.Subtraction(a, b);
            Assert.That(result, Is.EqualTo(expected));

        }

        [Test]
        [TestCase(1, 2, 2)]
        [TestCase(0, 1, 0)]
        [TestCase(-1, 2, -2)]
        public void Multiplication_WhenCalled_ShouldReturnTheProductOfArguments(double a, double b, double expected)
        {
            var result = _calc.Multiplication(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 0.5)]
        [TestCase(10, 5, 2)]
        public void Division_WhenCalled_ShouldReturnTheQuotientOfTheArguments(double a, double b, double expected)
        {
            try
            {
                var result = _calc.Division(a, b);
                Assert.That(result, Is.EqualTo(expected));
            }
            catch (ArgumentException e)
            {

                Assert.Fail(e.Message);
            }
        }
        [Test]
        [TestCase(1, 2, 3)]
        public void TestAddAndClear(double a, double b, double expected)
        {
            var result = _calc.Addition(a, b);
            Assert.AreEqual(expected, result);
            _calc.AllClear();
            result = _calc.GetResult;
            Assert.AreEqual(0, result);
        }
    }
}

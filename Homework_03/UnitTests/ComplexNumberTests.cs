using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    using Homework_03;
    using Homework.Utility;
    using System;

    [TestClass]
    public class ComplexNumberTests
    {
        ComplexNumber num1;
        ComplexNumber num2;
        ComplexNumber num3;
        ComplexNumber num4;
        ComplexNumber num5;
        ComplexNumber num6;
        ComplexNumber num7;
        ComplexNumber num8;
        ComplexNumber num9;

        [TestInitialize]
        public void TestInitialize()
        {
            num1 = new ComplexNumber(0, 0);
            num2 = new ComplexNumber(0, 10);
            num3 = new ComplexNumber(-5, 0);
            num4 = new ComplexNumber(10, 10);
            num5 = new ComplexNumber(-3, -7);
            num6 = new ComplexNumber(6, -12);
            num7 = new ComplexNumber(-2, 15);
            num8 = new ComplexNumber(1.2m, 12.7m);
            num9 = new ComplexNumber(-2.5m, -16.6m);
        }
        
        [TestMethod]
        public void OperatorDivideTest()
        {             
            Assert.IsTrue((num6 / num5).Equals(new ComplexNumber((33m/29), (39m/29))));
            Assert.IsTrue((num2 / num4).Equals(new ComplexNumber(0.5m, 0.5m)));
            Assert.IsTrue((num1 / num2).Equals(new ComplexNumber(0, 0)));
            Assert.AreEqual((num7 / num6).ToString(),new ComplexNumber(-(16m/15), (11m/30)).ToString());
            Assert.AreEqual((num9 / num8).ToString(),"- 1,31 + 0,07i");

        }

        [TestMethod]
        public void OperatorSumTest()
        {
            Assert.IsTrue((num3 + num4).Equals(new ComplexNumber(5, 10)));
            Assert.IsTrue((num5 + num7).Equals(new ComplexNumber(-5, 8)));
            Assert.IsTrue((num2 + num6).Equals(new ComplexNumber(6, -2)));
            Assert.IsTrue((num9 + num8).Equals(new ComplexNumber(-1.3m, -3.9m)));
            Assert.IsTrue((num8 + num5).Equals(new ComplexNumber(-1.8m, 5.7m)));
        }

        [TestMethod]
        public void OperatorDeductTest()
        {
            Assert.IsTrue((num7 - num1).Equals(new ComplexNumber(-2, 15)));
            Assert.IsTrue((num6 - num2).Equals(new ComplexNumber(6, -22)));
            Assert.IsTrue((num5 - num4).Equals(new ComplexNumber(-13, -17)));
            Assert.IsTrue((num9 - num8).Equals(new ComplexNumber(-3.7m, -29.3m)));
            Assert.IsTrue((num2 - num9).Equals(new ComplexNumber(2.5m, 26.6m)));
        }

        [TestMethod]
        public void OperatorMultiplicationTest()
        {
            Assert.IsTrue((num2 * num1).Equals(new ComplexNumber(0, 0)));
            Assert.IsTrue((num4 * num3).Equals(new ComplexNumber(-50, -50)));
            Assert.IsTrue((num6 * num5).Equals(new ComplexNumber(-102, -6)));
            Assert.IsTrue((num2 * num4).Equals(new ComplexNumber(-100, 100)));
            Assert.IsTrue((num4 * num4).Equals(new ComplexNumber(0, 200)));
            Assert.IsTrue((num8 * num9).Equals(new ComplexNumber(207.82m, -51.67m)));
            Assert.IsTrue((num8 * num7).Equals(new ComplexNumber(-192.9m, -7.4m)));
        }


        

        [TestMethod]
        public void ToStringTest()
        {
            Assert.AreEqual(num6.ToString(), "6,00 - 12,00i");
            Assert.AreEqual(num1.ToString(), "0,00 + 0,00i");
            Assert.AreEqual(num3.ToString(), "- 5,00 + 0,00i");
            Assert.AreEqual(num5.ToString(), "- 3,00 - 7,00i");
            Assert.AreEqual(num8.ToString(), "1,20 + 12,70i");
            Assert.AreEqual(num9.ToString(), "- 2,50 - 16,60i");
        }

        [TestMethod]
        public void ConstructorTest()
        {
            Assert.AreEqual(num2.Re, 0);
            Assert.AreEqual(num2.Im, 10);
            Assert.AreEqual(num4.Re, 10);
            Assert.AreEqual(num4.Im, 10);
            Assert.AreEqual(num5.Im, -7);
            Assert.AreEqual(num7.Re, -2);
        }

        [TestMethod]
        public void EmptyConstructorTest()
        {
            var num = new ComplexNumber();
            Assert.AreEqual(0, num.Re);
            Assert.AreEqual(0, num.Im);
            Assert.AreEqual(num.ToString(), "0,00 + 0,00i");
        }

        [TestMethod]
        public void EqualsTest()
        {
            Assert.IsTrue(num1.Equals(new ComplexNumber(0, 0)));
            Assert.IsTrue(num3.Equals(new ComplexNumber(-5, 0)));
            Assert.IsTrue(num5.Equals(new ComplexNumber(-3, -7)));
            Assert.IsTrue(num8.Equals(new ComplexNumber(1.2m, 12.7m)));
        }

        
    }
}

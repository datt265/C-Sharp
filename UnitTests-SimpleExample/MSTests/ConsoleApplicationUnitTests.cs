using ConsoleApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApplicationUnitTests
{
    [TestClass]
    public class Class1
    {
        [TestMethod]
        public void NegativeNumber()
        {
            Assert.AreEqual(10, new Math().Abs(-10));
        }

        [TestMethod]
        public void Zero()
        {
            Assert.AreEqual(0, new Math().Abs(0));
        }

        [TestMethod]
        public void PositiveNumber()
        {
            Assert.AreEqual(5, new Math().Abs(5));
        }


    }
}

using System;
using Moq;
using MoqTestExample.DataAccess;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace MoqTestExample.UnitTests
{
    [TestFixture]
    public class BasketTest
    {
        private Basket _target;
        private Mock<IBasketDal> _mock;

        [SetUp]
        public void Setup()
        {
            // Our MockBehavior is set to strict.
            _mock = new Mock<IBasketDal>(MockBehavior.Strict);

            _target = new Basket(_mock.Object);
        }

        [Test]
        public void CalculateBasketTotals_ValidBasket_ReturnsCorrectTotals()
        {
            // Build up our mock object
            DataAccess.Basket basket = new DataAccess.Basket
                                           {
                                               CustomerName = "Dean",
                                               ProductId = 123,
                                               ShippingPrice = 5.50F,
                                               SubTotal = 20,
                                               Total = 20
                                           };

            // Setup 
            _mock.Setup(x => x.GetBasket(It.IsAny<int>())).Returns(basket);

            // Get the customer name
            _mock.Setup(x => x.GetCustomerName(It.IsAny<int>())).Returns("Homer Simpson");

            DataAccess.Basket totals = _target.CalculateBasketTotals(1);

            Assert.That(totals.Total, Is.EqualTo(25.5), "The basket totals did not add up correctly");
        }

        [Test]
        public void CalculateBasketTotals_CheckWasCalled()
        {
            // return an empty basket object
            _mock.Setup(x => x.GetBasket(It.IsAny<int>())).
                Returns(new DataAccess.Basket());

            // Get the customer name
            _mock.Setup(x => x.GetCustomerName(It.IsAny<int>())).
                Returns("Homer Simpson");

            // call the method
            _target.CalculateBasketTotals(1);

            // verify that it was called
            _mock.Verify(x => x.GetBasket(It.IsAny<int>()), Times.Once());
        }

        [Test]
        [ExpectedException()]
        public void CalculateBasketTotals_ThrowsException()
        {
            // Check that an exception was thrown
            _mock.Setup(x => x.GetBasket(It.IsAny<int>()))
                .Throws(new ArgumentOutOfRangeException());

            // call the method as normal
            _target.CalculateBasketTotals(1);
        }

        /// <summary>
        /// This should throw an exception because we havent 
        /// setup a return for GetCustomerName. If we turn option strict off 
        /// this will pass.
        /// </summary>
        [Test]
        public void CalculateBasketTotals_VerifyAll()
        {
            // return an empty basket object
            _mock.Setup(x => x.GetBasket(It.IsAny<int>())).Returns(new DataAccess.Basket());

            // call the method
            _target.CalculateBasketTotals(1);

            // verify that it was called
            _mock.VerifyAll();
        }

    }
}

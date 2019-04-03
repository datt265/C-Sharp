using MoqTestExample.DataAccess;

namespace MoqTestExample
{
    public class Basket
    {
        private readonly IBasketDal _basketDal;

        public Basket(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        /// <summary>
        /// Calculates the basket totals.
        /// </summary>
        /// <param name="customerId">The customer id.</param>
        public DataAccess.Basket CalculateBasketTotals(int customerId)
        {
            // Retrieve the basket
            DataAccess.Basket basket = _basketDal.GetBasket(customerId);

            // Get the customer name
            string customerName = _basketDal.GetCustomerName(customerId);

            // Set the customer name
            basket.CustomerName = customerName;

            // Add the shipping price to the basket.
            basket.Total += basket.ShippingPrice;

            return basket;
        }
    }
}

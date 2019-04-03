using System;

namespace MoqTestExample.DataAccess
{
    public class BasketDal : IBasketDal
    {
        /// <summary>
        /// Gets the basket.
        /// </summary>
        /// <param name="customerId">The customer id.</param>
        /// <returns></returns>
        public Basket GetBasket(int customerId)
        {
            // This is where we would connect to DB and return logic
            // Ignore the DB logic for this example
            return null;
        }

        /// <summary>
        /// Gets the name of the customer.
        /// </summary>
        /// <param name="customerId">The customer id.</param>
        /// <returns></returns>
        public string GetCustomerName(int customerId)
        {
            // This is where we would connect to DB and return logic
            // Ignore the DB logic for this example
            return string.Empty;
        }
    }
}

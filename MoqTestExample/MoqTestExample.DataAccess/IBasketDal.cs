namespace MoqTestExample.DataAccess
{
    public interface IBasketDal
    {
        Basket GetBasket(int customerId);

        string GetCustomerName(int customerId);
    }

}

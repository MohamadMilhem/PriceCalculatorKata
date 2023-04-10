namespace PriceCalculatorKata.Discounts
{
    public interface IDiscountRepository
    {
        List<Discount> GetAll();
        IEnumerable<Discount> GetDiscountsByUPC(long UPC);
    }
}
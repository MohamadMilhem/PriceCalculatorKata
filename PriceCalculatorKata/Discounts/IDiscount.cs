namespace PriceCalculatorKata.Discounts
{
    public interface IDiscount
    {
        decimal DiscountPrecentage { get; set; }
        long ProductUPC { get; set; }
    }
}
namespace PriceCalculatorKata.Products
{
    public interface IProduct
    {
        decimal BasePrice { get; set; }
        string Name { get; set; }
        long UPC { get; set; }
        CurrencyType CurrencyType { get; set; }
     }
}
namespace PriceCalculatorKata.Products
{
    public interface IProductRepository
    {
        IProduct? GetProductByUPC(long UPC);
        List<IProduct> GetProducts();
    }
}
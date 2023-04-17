namespace PriceCalculatorKata.Taxs
{
    public interface ITaxRepository
    {
        List<Tax> GetAll();
        IEnumerable<Tax> GetTaxesByUPC(long UPC);
    }
}
namespace PriceCalculatorKata.Caps
{
    public interface ICapRepository
    {
        List<Cap> GetAll();
        IEnumerable<Cap> GetCapsByUPC(long UPC);
    }
}
namespace PriceCalculatorKata.Caps
{
    public interface ICap
    {
        decimal Amount { get; set; }
        CapType CapType { get; set; }
        long ProductUPC { get; set; }
    }
}
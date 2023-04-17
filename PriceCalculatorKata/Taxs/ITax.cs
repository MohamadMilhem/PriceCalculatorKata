namespace PriceCalculatorKata.Taxs
{
    public interface ITax
    {
        bool IsUniversal { get; set; }
        long ProductUPC { get; set; }
        decimal TaxPercentage { get; set; }

        string ToString();
    }
}
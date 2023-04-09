using PriceCalculatorKata.Products;
using PriceCalculatorKata.Taxs;
using System.Net.Mail;

namespace PriceCalculatorKata
{
    public class Program
    {
        static void Main(string[] args)
        {

            var SampleProduct = new Product("The Little Prince" , 12345, 20.25m);
            Console.WriteLine(SampleProduct.ToString());
            var ApplyTax = new Tax(SampleProduct.OriginalPrice, 20m);
            Console.WriteLine(ApplyTax.ToString());
            ApplyTax.TaxPercentage = 21;
            Console.WriteLine(ApplyTax.ToString());

        }
    }
}
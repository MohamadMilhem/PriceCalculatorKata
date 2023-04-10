using PriceCalculatorKata.Products;
using PriceCalculatorKata.Taxs;
using PriceCalculatorKata.Discounts;
using System.Net.Mail;

namespace PriceCalculatorKata
{
    public class Program
    {
        static void Main(string[] args)
        {

            var SampleProduct = new Product("The Little Prince" , 12345, 20.25m);
            Console.WriteLine(SampleProduct.ToString());
            var Tax = new Tax(SampleProduct.BasePrice, 20m);
            var Discount = new Discount(SampleProduct.BasePrice, 15);

            var FinalPrice = SampleProduct.BasePrice + Tax.TaxAmount() - Discount.DiscountAmount();

            Console.WriteLine($"The base price was {SampleProduct.BasePrice}, the final price is {FinalPrice}");


        }
    }
}
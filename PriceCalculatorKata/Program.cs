using PriceCalculatorKata.Products;
using PriceCalculatorKata.Interconnection;
using PriceCalculatorKata.Taxs;
using PriceCalculatorKata.Discounts;
using PriceCalculatorKata.ConsolePrinter;
using System.Net.Mail;

namespace PriceCalculatorKata
{
    public class Program
    {
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Enter UPC of a product :");
                var optionFromConsole = Console.ReadLine();
   
                if (optionFromConsole == null)
                {
                    Console.WriteLine("Please try Again...");
                    continue;
                }

                var option = long.Parse(optionFromConsole);
                var ProductsOnline = new ProductRepository();
                var ProductEntered = ProductsOnline.GetProductByUPC(option);
              

                if (ProductEntered == null)
                {
                    Console.WriteLine("This product does not exist. Please try again...");
                    continue;
                }

                var Printer = Interconnections.CreateConsolePrint(option);

                Printer.ReportExpenses();
                Printer.ReportDiscount();

            }


            


        }



    }
}
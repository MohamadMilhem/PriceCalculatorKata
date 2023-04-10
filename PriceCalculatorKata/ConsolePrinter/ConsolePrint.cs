using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata.ConsolePrinter
{
    public static class ConsolePrint
    {
        public static void ReportDiscount(decimal FinalPrice, decimal DiscountAmount)
        {
            Console.WriteLine($"The Price is {FinalPrice}");
            if (DiscountAmount > 0)
            {
                Console.WriteLine($"with discount ${DiscountAmount}");
            }
        }




    }
}

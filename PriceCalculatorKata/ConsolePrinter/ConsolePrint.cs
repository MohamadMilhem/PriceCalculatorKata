using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculatorKata.Products;

namespace PriceCalculatorKata.ConsolePrinter
{
    public static class ConsolePrint
    {
        public static void ReportDiscount(ProductCalucations Calculations)
        {
            Console.WriteLine($"The Price is ${Calculations.ProductCalculateFinalPrice()}");
            if (Calculations.ProductCalculateDiscountAmount() > 0)
            {
                Console.WriteLine($"with discount ${Calculations.ProductCalculateDiscountAmount()}");
            }
        }




    }
}

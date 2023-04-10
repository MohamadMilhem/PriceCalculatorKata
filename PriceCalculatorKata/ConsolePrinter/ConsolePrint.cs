using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculatorKata.Products;

namespace PriceCalculatorKata.ConsolePrinter
{
    public class ConsolePrint
    {
        private Product Product { get; set; }
        private ProductCalculations Calculations { get; set; }
       
        public ConsolePrint(Product product) 
        {
            this.Product = product;
            this.Calculations = new ProductCalculations(product);
        }


        public void ReportDiscount()
        {
            Console.WriteLine(Product.ToString());
            Console.WriteLine($"Base Price : ${Calculations.FinalPrice()}");
            Console.WriteLine($"Discount Price: ${Calculations.GetTotalDiscount()}");
        }


    }
}

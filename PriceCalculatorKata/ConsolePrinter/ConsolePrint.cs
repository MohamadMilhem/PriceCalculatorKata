using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculatorKata.Expenses;
using PriceCalculatorKata.Products;

namespace PriceCalculatorKata.ConsolePrinter
{
    public class ConsolePrint : IConsolePrint
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
            Console.WriteLine($"Discount Price: ${Calculations.MaximunDiscount()}");
        }

        public void ReportExpenses()
        {
            Console.WriteLine($"Cost = ${Product.BasePrice}");
            Console.WriteLine($"Tax = ${Calculations.GetTotalTax()}");
            Console.WriteLine($"Discount = ${Calculations.MaximunDiscount()}");

            var Expenses = new ExpensesRepository().GetExpensesByUPC(Product.UPC);

            foreach (var expense in Expenses)
            {
                Console.WriteLine($"{expense.Description} = ${Calculations.ExpenseAmount(expense)}");
            }

            Console.WriteLine($"Total = ${Calculations.FinalPrice()}");

        }


    }
}

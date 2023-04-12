using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculatorKata.Expenses;
using PriceCalculatorKata.Products;
using PriceCalculatorKata.Currency;

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
            Console.WriteLine($"Base Price : {Calculations.FinalPrice()} {CurrencyFormater.CurrencyFromat(Product.CurrencyType)}");
            Console.WriteLine($"Discount Price: ${Calculations.MaximunDiscount()} {CurrencyFormater.CurrencyFromat(Product.CurrencyType)}");
        }

        public void ReportExpenses()
        {
            Console.WriteLine($"Cost = {Product.BasePrice} {CurrencyFormater.CurrencyFromat(Product.CurrencyType)}");
            Console.WriteLine($"Tax = {Calculations.GetTotalTax()} {CurrencyFormater.CurrencyFromat(Product.CurrencyType)}");
            Console.WriteLine($"Discount = {Calculations.MaximunDiscount()} {CurrencyFormater.CurrencyFromat(Product.CurrencyType)}");

            var Expenses = new ExpensesRepository().GetExpensesByUPC(Product.UPC);

            foreach (var expense in Expenses)
            {
                Console.WriteLine($"{expense.Description} = {Calculations.ExpenseAmount(expense)} {CurrencyFormater.CurrencyFromat(Product.CurrencyType)}");
            }

            Console.WriteLine($"Total = {Calculations.FinalPrice()} {CurrencyFormater.CurrencyFromat(Product.CurrencyType)}");

        }


    }
}

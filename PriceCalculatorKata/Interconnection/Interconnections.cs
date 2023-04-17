using PriceCalculatorKata.Caps;
using PriceCalculatorKata.ConsolePrinter;
using PriceCalculatorKata.Discounts;
using PriceCalculatorKata.Expenses;
using PriceCalculatorKata.Products;
using PriceCalculatorKata.Taxs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata.Interconnection
{
    public static class Interconnections
    {

        public static IProduct CreateProduct(string name, long upc, decimal price)
        {
            return new Product(name, upc, price);
        }

        public static IDiscount CreateDiscount(decimal percentage)
        {
            return new Discount(percentage);
        }

        public static IDiscount CreateUPCDiscount(decimal percentage, long upc)
        {
            return new Discount(percentage, upc);
        }

        public static ITax CreateTax(decimal percentage)
        {
            return new Tax(percentage);
        }

        public static ITax CreateTax(decimal percentage, long upc)
        {
            return new Tax(upc, percentage);
        }

        public static IExpenses CreateExpense(decimal amount, ExpenseType expenseType, string description)
        {
            return new Expense(amount, expenseType, description);
        }

        public static ICap CreateCap(decimal amount, CapType capType)
        {
            return new Cap(amount, capType);
        }

        public static IConsolePrint CreateConsolePrint(long upc)
        {
            return new ConsolePrint(upc, CreateProductRepository(), CreateProductCalculations(upc));
        }


        public static IProductRepository CreateProductRepository()
        {
            return new ProductRepository();
        }

        public static IDiscountRepository CreateDiscountRepository()
        {
            return new DiscountRepository();
        }

        public static ITaxRepository CreateTaxRepository()
        {
            return new TaxRepository();
        }

        public static IExpensesRepository CreateExpenseRepository()
        {
            return new ExpensesRepository();
        }

        public static ICapRepository CreateCapRepository()
        {
            return new CapRepository();
        }

        public static IProductCalculations CreateProductCalculations(long upc)
        {
            return new ProductCalculations(upc, CreateProductRepository(), CreateTaxRepository(), CreateDiscountRepository(), CreateExpenseRepository(), CreateCapRepository());
        }


    }
}

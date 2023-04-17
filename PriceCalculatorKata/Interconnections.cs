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

namespace PriceCalculatorKata
{
    public class Interconnections
    {

        public IProduct CreateProduct(string name , long upc, decimal price)
        {
            return new Product(name, upc, price);
        }

        public IDiscount CreateDiscount(decimal percentage)
        {
            return new Discount(percentage);
        }

        public IDiscount CreateUPCDiscount(decimal percentage, long upc)
        {
            return new Discount(percentage, upc);
        }

        public ITax CreateTax(decimal percentage)
        {
            return new Tax(percentage);
        }

        public ITax CreateTax(decimal percentage, long upc)
        {
            return new Tax(upc, percentage);
        }

        public IExpenses CreateExpense(decimal amount , ExpenseType expenseType, string description)
        {
            return new Expense(amount, expenseType, description);
        }

        public ICap CreateCap(decimal amount, CapType capType)
        {
            return new Cap(amount, capType);
        }

        public IConsolePrint CreateConsolePrint(long upc)
        {
            return new ConsolePrint(upc ,CreateProductRepository(), CreateProductCalculations(upc));
        }


        public IProductRepository CreateProductRepository()
        {
            return new ProductRepository();
        }

        public IDiscountRepository CreateDiscountRepository()
        {
            return new DiscountRepository();
        }

        public ITaxRepository CreateTaxRepository() 
        {
            return new TaxRepository();
        }

        public IExpensesRepository CreateExpenseRepository() 
        {
            return new ExpensesRepository();
        }

        public ICapRepository CreateCapRepository() 
        {
            return new CapRepository();
        }

        public IProductCalculations CreateProductCalculations(long upc)
        {
            return new ProductCalculations(upc, CreateProductRepository(), CreateTaxRepository(), CreateDiscountRepository(), CreateExpenseRepository(), CreateCapRepository());
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculatorKata.Discounts;
using PriceCalculatorKata.Taxs;
using PriceCalculatorKata.ConsolePrinter;
using PriceCalculatorKata.Expenses;

namespace PriceCalculatorKata.Products
{
    public class ProductCalucations
    {

        private readonly Product _product;
        private readonly TaxRepository _taxes;
        private readonly DiscountRepository _discounts;
<<<<<<< Updated upstream
        public ProductCalucations(Product product)
=======
        private readonly ExpenseRepository _expensesRepository;
        public ProductCalculations(Product product)
>>>>>>> Stashed changes
        {
            this._product = product;
            this._taxes = new TaxRepository();
            this._discounts = new DiscountRepository();
            this._expensesRepository = new ExpenseRepository();
        }


        public decimal ProductCalculateTotalTax()
        {
<<<<<<< Updated upstream
            return Math.Round(_taxes.GetDiscountsByUPC(_product.UPC).Sum(tax => tax.TaxPercentage), 2);
=======
            var TotalDiscount = GetTotalDiscount();
            var TotalTax = GetTotalTax();
            var TotalExpenses = GetTotalExpenses();

            return Math.Round(_product.BasePrice + TotalTax - TotalDiscount + TotalExpenses, 2);
        }

        public decimal GetTotalExpenses()
        {
            var SumPrecentageExpenses = SumProductExpensesByType(ExpenseType.Percentage);
            var SumAbsoluteExpenses = SumProductExpensesByType(ExpenseType.Absolute);

            return  Math.Round(GetAmount(ExpenseType.Absolute,SumAbsoluteExpenses) + GetAmount(ExpenseType.Percentage ,SumPrecentageExpenses), 2);

        }

        public decimal GetAmount(ExpenseType expenseType, decimal Amount)
        {
            if (expenseType == ExpenseType.Percentage)
            {
                return Math.Round(_product.BasePrice * Amount, 2);
            }

            return Math.Round(Amount, 2);
>>>>>>> Stashed changes
        }


        public decimal ProductCalculateTotalDiscount()
        {
            return Math.Round(_discounts.GetDiscountsByUPC(_product.UPC).Sum(discount => discount.DiscountPrecentage),2);
        }


        public decimal ProductCalculateTaxAmount()
        {
            var TotalTaxFraction = ProductCalculateTotalTax() / 100;
            return Math.Round(_product.BasePrice * TotalTaxFraction, 2);
        }

        public decimal ProductCalculateDiscountAmount()
        {
<<<<<<< Updated upstream
            var TotalDiscountFraction = ProductCalculateTotalDiscount() / 100;
            return Math.Round( _product.BasePrice * TotalDiscountFraction, 2);
=======
            return Math.Round(_taxes.GetTaxesByUPC(_product.UPC).Sum(tax => tax.TaxPercentage), 2);
>>>>>>> Stashed changes
        }

        public decimal ProductCalculateFinalPrice()
        {
<<<<<<< Updated upstream
            var FinalPrice = _product.BasePrice + ProductCalculateTaxAmount() - ProductCalculateDiscountAmount();
            return FinalPrice;
=======
            var BeforeTax = BeforeTaxDiscountsAmount();
            var AfterTax = AfterTaxDiscountsAmount(BeforeTax);
            return Math.Round(BeforeTax + AfterTax, 2);
        }

        public decimal BeforeTaxDiscountsAmount()
        {
            var DiscountPrecentageBefore = DiscountBeforePrecentageSum();

            var PriceBefore = _product.BasePrice;
            return Math.Round(PriceBefore * DiscountPrecentageBefore, 2);
        }

        public decimal DiscountBeforePrecentageSum()
        {
            return Math.Round(_discounts.GetDiscountsByUPC(_product.UPC)
                                .Where(discount => discount.DiscountType == DiscountType.BeforeTax)
                                        .Sum(discount => discount.DiscountPrecentage), 2);
        }

        public decimal AfterTaxDiscountsAmount(decimal BeforeTax)
        {
            var DiscountPrecentageAfter = DiscountAfterPrecentageSum();
            var PriceAfter = _product.BasePrice - BeforeTax;

            return Math.Round(PriceAfter * DiscountPrecentageAfter, 2);
        }

        public decimal DiscountAfterPrecentageSum()
        {
            return Math.Round(_discounts.GetDiscountsByUPC(_product.UPC)
                                .Where(discount => discount.DiscountType == DiscountType.AfterTax)
                                    .Sum(discount => discount.DiscountPrecentage), 2);
>>>>>>> Stashed changes
        }

        public IEnumerable<Expense> ProductExpenses()
        {
            return _expensesRepository.GetExpensesByUPC(_product.UPC);
        }

        public decimal SumProductExpensesByType(ExpenseType type)
        {
            return Math.Round(ProductExpenses().Where(expense => expense.Type == type).Sum(expense => expense.Amount), 2);
        }


    }
}

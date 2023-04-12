using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculatorKata.Discounts;
using PriceCalculatorKata.Taxs;
using PriceCalculatorKata.ConsolePrinter;
using PriceCalculatorKata.Expenses;
using PriceCalculatorKata.Caps;

namespace PriceCalculatorKata.Products
{
    public class ProductCalculations
    {
        private readonly DiscountCalculatingType _discountCalculatingType = DiscountCalculatingType.Additive;
        private readonly Product _product;
        private readonly TaxRepository _taxes;
        private readonly DiscountRepository _discounts;
        private readonly ExpensesRepository _expenses;
        private readonly CapRepository _caps;
        public ProductCalculations(Product product)
        {
            this._product = product;
            this._taxes = new TaxRepository();
            this._discounts = new DiscountRepository();
            this._expenses = new ExpensesRepository();
            this._caps = new CapRepository();
        }


        public decimal FinalPrice()
        {
            var TotalDiscount = MaximunDiscount();
            var TotalTax = GetTotalTax();
            var TotalExpenses = GetTotalExpenses();

            return Math.Round(_product.BasePrice + TotalTax + TotalExpenses - TotalDiscount, 2);
        }

        public decimal MaximunDiscount()
        {
            return Math.Min(GetTotalDiscount(), GetCap());
        }

        public decimal GetCap()
        {
            return _caps.GetCapsByUPC(_product.UPC).Min(cap => CapAmount(cap));
        }

        public decimal CapAmount(Cap cap)
        {
            if (cap.CapType == CapType.Absolute)
            {
                return cap.Amount;
            }

            return Math.Round(cap.Amount * _product.BasePrice, 2);
        }

        public decimal GetTotalExpenses()
        {
            var AllExpensesForThisProduct = _expenses.GetExpensesByUPC(_product.UPC);
            decimal TotalExpenses = 0;

            foreach (var Expense in AllExpensesForThisProduct)
            {
                TotalExpenses += ExpenseAmount(Expense);
            }

            return Math.Round(TotalExpenses, 2);

        }

        public decimal ExpenseAmount(Expense Expense)
        {
            if (Expense.ExpenseType == ExpenseType.Absolute)
            {
                return Math.Round(Expense.Amount, 2);
            }

            return Math.Round(_product.BasePrice * Expense.Amount, 2);
        }
        


        public decimal GetTotalTax()
        {
            var BeforeTaxDiscounts = BeforeTaxDiscountsAmount();
            var Tax = GetTax(BeforeTaxDiscounts);

            return Math.Round(Tax, 2);
        }

        public decimal GetTax(decimal BeforeApplyingTaxDiscounts)
        {
            var TaxPrecentage = TaxPrecentageSum();
            var PriceAfterApplyingDiscounts = _product.BasePrice - BeforeApplyingTaxDiscounts;

            return Math.Round(PriceAfterApplyingDiscounts * TaxPrecentage, 2);
        }

        public decimal TaxPrecentageSum()
        {
            return _taxes.GetTaxesByUPC(_product.UPC).Sum(tax => tax.TaxPercentage);
        }

        public decimal GetTotalDiscount()
        {
            var BeforeTax = BeforeTaxDiscountsAmount();
            var AfterTax = AfterTaxDiscountsAmount(BeforeTax);
            return Math.Round(BeforeTax + AfterTax, 2);
        }

        public decimal BeforeTaxDiscountsAmount()
        {
            var DiscountPrecentageBefore = 0m;
            if (_discountCalculatingType == DiscountCalculatingType.Additive)
            {
                DiscountPrecentageBefore = DiscountPrecentageSum(DiscountType.BeforeTax);
            }

            else if (_discountCalculatingType == DiscountCalculatingType.Multiplicative)
            {
                DiscountPrecentageBefore = DiscountPrecentageMultiply(DiscountType.BeforeTax);
            }


            var PriceBefore = _product.BasePrice;
            return Math.Round(PriceBefore * DiscountPrecentageBefore, 2);
        }

        public decimal DiscountPrecentageSum(DiscountType DiscountType)
        {
            return _discounts.GetDiscountsByUPC(_product.UPC)
                        .Where(discount => discount.DiscountType == DiscountType)
                              .Sum(discount => discount.DiscountPrecentage);
        }

        public decimal DiscountPrecentageMultiply(DiscountType DiscountType)
        {
            var discounts = _discounts.GetDiscountsByUPC(_product.UPC)
                                .Where(discount => discount.DiscountType == DiscountType);

            var answer = 0m;

            decimal Precentage = 1.0m;
            foreach (var discount in discounts)
            {
                var PrecentageNow = discount.DiscountPrecentage * Precentage;
                Precentage -= PrecentageNow;
                answer+= PrecentageNow;
            }

            return answer;

        }


        public decimal AfterTaxDiscountsAmount(decimal BeforeTax)
        {
            var DiscountPrecentageAfter = 0m;
            if (_discountCalculatingType == DiscountCalculatingType.Additive)
            {
                DiscountPrecentageAfter = DiscountPrecentageSum(DiscountType.AfterTax);
            }

            else if (_discountCalculatingType == DiscountCalculatingType.Multiplicative)
            {
                DiscountPrecentageAfter = DiscountPrecentageMultiply(DiscountType.AfterTax);
            }

            var PriceAfter = _product.BasePrice - BeforeTax;
            return Math.Round(PriceAfter * DiscountPrecentageAfter, 2);
        }


    }
}

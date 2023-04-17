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
using System.Reflection.Metadata;
using System.Numerics;

namespace PriceCalculatorKata.Products
{
    public class ProductCalculations : IProductCalculations
    {

        private readonly int Precision = 4;
        private readonly DiscountCalculatingType _discountCalculatingType = DiscountCalculatingType.Additive;
        private readonly IProductRepository? _products;
        private readonly ITaxRepository _taxes;
        private readonly IDiscountRepository _discounts;
        private readonly IExpensesRepository _expenses;
        private readonly ICapRepository _caps;
        private readonly IProduct _product;
        public ProductCalculations(long upc, IProductRepository products, ITaxRepository taxes, IDiscountRepository discounts, IExpensesRepository expenses, ICapRepository caps)
        {
            this._products = products;
            this._taxes = taxes;
            this._discounts = discounts;
            this._expenses = expenses;
            this._caps = caps;
            this._product = _products.GetProductByUPC(upc);

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

            return Math.Round(cap.Amount * _product.BasePrice, Precision);
        }

        public decimal GetTotalExpenses()
        {
            var AllExpensesForThisProduct = _expenses.GetExpensesByUPC(_product.UPC);
            decimal TotalExpenses = 0;

            foreach (var Expense in AllExpensesForThisProduct)
            {
                TotalExpenses += ExpenseAmount(Expense);
            }

            return Math.Round(TotalExpenses, Precision);

        }

        public decimal ExpenseAmount(Expense Expense)
        {
            if (Expense.ExpenseType == ExpenseType.Absolute)
            {
                return Math.Round(Expense.Amount, Precision);
            }

            return Math.Round(_product.BasePrice * Expense.Amount, Precision);
        }



        public decimal GetTotalTax()
        {
            var BeforeTaxDiscounts = BeforeTaxDiscountsAmount();
            var Tax = GetTax(BeforeTaxDiscounts);

            return Math.Round(Tax, Precision);
        }

        public decimal GetTax(decimal BeforeApplyingTaxDiscounts)
        {
            var TaxPrecentage = TaxPrecentageSum();
            var PriceAfterApplyingDiscounts = _product.BasePrice - BeforeApplyingTaxDiscounts;

            return Math.Round(PriceAfterApplyingDiscounts * TaxPrecentage, Precision);
        }

        public decimal TaxPrecentageSum()
        {
            return _taxes.GetTaxesByUPC(_product.UPC).Sum(tax => tax.TaxPercentage);
        }

        public decimal GetTotalDiscount()
        {
            var BeforeTax = BeforeTaxDiscountsAmount();
            var AfterTax = AfterTaxDiscountsAmount(BeforeTax);
            return Math.Round(BeforeTax + AfterTax, Precision);
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
            return Math.Round(PriceBefore * DiscountPrecentageBefore, Precision);
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
                answer += PrecentageNow;
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
            return Math.Round(PriceAfter * DiscountPrecentageAfter, Precision);
        }


    }
}

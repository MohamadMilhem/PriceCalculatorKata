using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculatorKata.Discounts;
using PriceCalculatorKata.Taxs;
using PriceCalculatorKata.ConsolePrinter;

namespace PriceCalculatorKata.Products
{
    public class ProductCalculations
    {

        private readonly Product _product;
        private readonly TaxRepository _taxes;
        private readonly DiscountRepository _discounts;
        public ProductCalculations(Product product)
        {
            this._product = product;
            this._taxes = new TaxRepository();
            this._discounts = new DiscountRepository();
        }


        public decimal FinalPrice()
        {
            var TotalDiscount = GetTotalDiscount();
            var TotalTax = GetTotalTax();

            return Math.Round(_product.BasePrice + TotalTax - TotalDiscount, 2);
        }

        public decimal GetTotalTax()
        {
            var BeforeTaxDiscounts = BeforeTaxDiscountsAmount();
            var Tax = GetTax(BeforeTaxDiscounts);

            return Math.Round(Tax, 2);
        }

        public decimal GetTax(decimal BeforeDiscounts)
        {
            var TaxPrecentage = TaxPrecentageSum();
            var PriceAfterApplyingDiscounts = _product.BasePrice - BeforeDiscounts;

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
            var DiscountPrecentageBefore = DiscountBeforePrecentageSum();

            var PriceBefore = _product.BasePrice;
            return Math.Round(PriceBefore * DiscountPrecentageBefore, 2);
        }

        public decimal DiscountBeforePrecentageSum()
        {
            return _discounts.GetDiscountsByUPC(_product.UPC)
                        .Where(discount => discount.DiscountType == DiscountType.BeforeTax)
                              .Sum(discount => discount.DiscountPrecentage);
        }

        public decimal AfterTaxDiscountsAmount(decimal BeforeTax)
        {
            var DiscountPrecentageAfter = DiscountAfterPrecentageSum();
            var PriceAfter = _product.BasePrice - BeforeTax;

            return Math.Round(PriceAfter * DiscountPrecentageAfter, 2);
        }

        public decimal DiscountAfterPrecentageSum()
        {
            return _discounts.GetDiscountsByUPC(_product.UPC)
                             .Where(discount => discount.DiscountType == DiscountType.AfterTax)
                                   .Sum(discount => discount.DiscountPrecentage);
        }

    }
}

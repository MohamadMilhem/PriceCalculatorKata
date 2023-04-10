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
    public class ProductCalucations
    {

        private readonly Product _product;
        private readonly TaxRepository _taxes;
        private readonly DiscountRepository _discounts;
        public ProductCalucations(Product product)
        {
            this._product = product;
            this._taxes = new TaxRepository();
            this._discounts = new DiscountRepository();
        }


        public decimal ProductCalculateTotalTax()
        {
            return Math.Round(_taxes.GetDiscountsByUPC(_product.UPC).Sum(tax => tax.TaxPercentage), 2);
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
            var TotalDiscountFraction = ProductCalculateTotalDiscount() / 100;
            return Math.Round( _product.BasePrice * TotalDiscountFraction, 2);
        }

        public decimal ProductCalculateFinalPrice()
        {
            var FinalPrice = _product.BasePrice + ProductCalculateTaxAmount() - ProductCalculateDiscountAmount();
            return FinalPrice;
        }

    }
}

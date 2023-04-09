using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata.Taxs
{
    public class Tax
    {
        public decimal BasePrice { get; set; }
        public decimal TaxPercentage { get; set; } = 20m;


        public Tax() { }

        public Tax(decimal BasePrice, decimal TaxPercentage)
        {
            this.BasePrice = BasePrice;
            this.TaxPercentage = TaxPercentage; 
        }

        public decimal TaxAmount()
        {
            decimal TaxFraction = TaxPercentage / 100;
            return Math.Round(BasePrice * TaxFraction, 2);
        }

        public decimal PriceAfterTax()
        {
            return Math.Round(TaxAmount() + BasePrice, 2);
        }

        public override string ToString()
        {
            string TaxString = $"The Base Price was ${BasePrice}, after Applying the %{TaxPercentage} Tax the new price is ${PriceAfterTax()}";
            return TaxString;
        }


    }
}

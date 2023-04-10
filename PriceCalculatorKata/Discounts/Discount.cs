using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata.Discounts
{
    public class Discount
    {
        public decimal BasePrice { get; set; }

        public decimal DiscountPrecentage;


        public Discount() { }

        public Discount(decimal BasePrice, decimal DiscountPrecentage)
        {
            this.BasePrice = BasePrice;
            this.DiscountPrecentage = DiscountPrecentage;
        }

        public decimal DiscountAmount()
        {
            decimal DiscountFraction = DiscountPrecentage / 100;
            return Math.Round(BasePrice * DiscountFraction, 2);
        }



        public override string ToString()
        {
            string DiscountString = $"The Base Price was {BasePrice}, after applying the %{DiscountPrecentage} Discount the new price is {BasePrice - DiscountAmount()}.";
            return DiscountString;
        }


    }
}

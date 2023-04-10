using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata.Discounts
{
    public class Discount : IDiscount
    {

        public long ProductUPC { get; set; }
        public decimal DiscountPrecentage { set; get; }
        public bool IsUniversal { get; set; } = false;

        public Discount(decimal DiscountPrecentage)
        {
            this.DiscountPrecentage = DiscountPrecentage;
            this.IsUniversal = true;
        }

        public Discount(decimal DiscountPrecentage, long ProductUPC)
        {
            this.DiscountPrecentage = DiscountPrecentage;
            this.ProductUPC = ProductUPC;
        }

        public override string ToString()
        {
            string DiscountString = $"Product with UPC : {ProductUPC} have Discount of Precentage {DiscountPrecentage}";
            return DiscountString;
        }

    }
}

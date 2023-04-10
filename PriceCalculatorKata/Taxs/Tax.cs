using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata.Taxs
{
    public class Tax
    {
        public long ProductUPC { get; set; }
        public decimal TaxPercentage { get; set; } = 0.20m;
        public bool IsUniversal { get; set; } = false;


        public Tax(decimal TaxPercentage)
        {
            this.TaxPercentage = TaxPercentage;
            this.IsUniversal = true;
        }

        public Tax(long ProductUPC, decimal TaxPercentage)
        {
            this.ProductUPC = ProductUPC;
            this.TaxPercentage = TaxPercentage;
        }


        public override string ToString()
        {
            string TaxString = $"Product with UPC : {ProductUPC} have a Tax with precentage {TaxPercentage}.";
            return TaxString;
        }


    }
}

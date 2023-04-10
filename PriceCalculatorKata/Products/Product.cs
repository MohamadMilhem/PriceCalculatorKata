using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata.Products
{
    public class Product
    {
        public string Name { get; set; } = string.Empty;
        public long UPC { get; set; }
        public decimal BasePrice { get; set; } = 0.00m;


        public Product()
        {
        }

        public Product(string Name, long UPC, decimal BasePrice)
        {
            this.Name = Name;
            this.UPC = UPC;
            this.BasePrice = BasePrice;
        }   

        public override string ToString()
        {
            string ProductString = $"Name : {Name}, UPC : {UPC}, Base Price: {BasePrice}";
            return ProductString;
        }


    }
}

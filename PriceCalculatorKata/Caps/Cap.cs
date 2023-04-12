using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata.Caps
{
    public class Cap : ICap
    {
        public decimal Amount { get; set; }

        public CapType CapType { get; set; }

        public long ProductUPC { get; set; }

        public Cap(decimal amount, CapType capType)
        {
            Amount = amount;
            CapType = capType;
        }
    }
}

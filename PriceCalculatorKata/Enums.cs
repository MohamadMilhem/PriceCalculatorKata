﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata
{
    public enum DiscountType { AfterTax, BeforeTax };

    public enum ExpenseType { Percentage, Absolute };

    public enum DiscountCalculatingType { Additive, Multiplicative };

    public enum CapType { Percentage, Absolute }

    public enum CurrencyType 
    {
        USD,
        GBP,
        JPY
    }
}

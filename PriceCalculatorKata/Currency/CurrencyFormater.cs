using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata.Currency
{
    public static class CurrencyFormater
    {
        private static List<string> Currencies = new List<string>() { "USA" , "GBP", "JPY" };

        public static string CurrencyFromat(CurrencyType currencyType)
        {
            return $"{Currencies.ElementAt((int)currencyType)}";
        }


    }
}

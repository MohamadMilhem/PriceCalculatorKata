using PriceCalculatorKata.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata.Taxs
{
    public class TaxRepository
    {
        private readonly List<Tax> _taxes;

        public TaxRepository()
        {
            _taxes = new List<Tax>()
            {
                new Tax(20),
            };
        }


        public List<Tax> GetAll()
        {
            return _taxes;
        }

        public IEnumerable<Tax> GetDiscountsByUPC(long UPC)
        {
            return _taxes.Where(tax => tax.IsUniversal || tax.ProductUPC == UPC);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata.Discounts
{
    public class DiscountRepository : IDiscountRepository
    {

        private readonly List<Discount> _discounts;

        public DiscountRepository()
        {
            _discounts = new List<Discount>()
            {
                new Discount(0.15m),
                new Discount(0.07m, 12345)
            };
        }

        public List<Discount> GetAll()
        {
            return _discounts;
        }

        public IEnumerable<Discount> GetDiscountsByUPC(long UPC)
        {
            return _discounts.Where(discount => discount.IsUniversal || discount.ProductUPC == UPC);
        }



    }
}

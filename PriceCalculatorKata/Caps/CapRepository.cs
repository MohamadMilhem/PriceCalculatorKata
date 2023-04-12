using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata.Caps
{
    public class CapRepository : ICapRepository
    {

        private readonly List<Cap> _caps;

        public CapRepository()
        {
            _caps = new List<Cap>()
            {
                new Cap(0.2m, CapType.Percentage){ProductUPC = 12345},
            };

        }


        public List<Cap> GetAll()
        {
            return _caps;
        }

        public IEnumerable<Cap> GetCapsByUPC(long UPC)
        {
            return _caps.Where(cap => cap.ProductUPC == UPC);
        }

    }
}

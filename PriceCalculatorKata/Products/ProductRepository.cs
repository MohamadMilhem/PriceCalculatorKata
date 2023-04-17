using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<IProduct> _products;


        public ProductRepository()
        {
            _products = new List<IProduct>
            {
                new Product ("The Little Prince", 12345, 20.25m)
            };
        }

        public List<IProduct> GetProducts()
        {
            return _products;
        }

        public IProduct? GetProductByUPC(long UPC)
        {
            return _products.FirstOrDefault(product => product.UPC == UPC);
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata.Products
{
    public class ProductRepository
    {
        private readonly List<Product> _products;


        public ProductRepository()
        {
            _products = new List<Product>
            {
                new Product ("The Little Prince", 12345, 20.25m)
            };
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public Product? GetProductByUPC(long UPC)
        {
            return _products.FirstOrDefault(product => product.UPC == UPC);
        }



    }
}

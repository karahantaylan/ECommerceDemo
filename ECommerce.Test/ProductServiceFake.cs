using ECommerce.Model;
using ECommerce.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ECommerce.Test
{
    public class ProductServiceFake : IProduct
    {
        private readonly List<ProductModel> _products;

        public ProductServiceFake()
        {
            _products = new List<ProductModel>()
            {
                new ProductModel() { ProductCode = 1,
                    Price = 100, Stock = 100 },
                new ProductModel() { ProductCode = 2,
                    Price = 200, Stock = 200 },
                new ProductModel() { ProductCode = 3,
                    Price = 300, Stock = 300 },
            };
        }


        public ProductModel Add(ProductModel product)
        {
            return product;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            return _products;
        }

        public ProductModel GetByProductCode(int productCode)
        {
            return _products.SingleOrDefault(x => x.ProductCode == productCode);
        }

        public void Update(ProductModel product)
        {
        }
    }
}

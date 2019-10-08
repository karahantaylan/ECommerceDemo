using ECommerce.Context;
using ECommerce.Model;
using ECommerce.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Service.DataService
{
    public class Product : IProduct
    {
        private readonly CoreDB _db;

        public Product(CoreDB db)
        {
            _db = db;
        }

        public ProductModel Add(ProductModel product)
        {
            var addedProduct = _db.Add(product);
            _db.SaveChanges();
            //product.ProductCode = addedProduct.Entity.ProductCode;

            return product;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            return _db.Product.ToList();
        }

        public ProductModel GetByProductCode(int productCode)
        {
            return _db.Product.SingleOrDefault(x => x.ProductCode == productCode);
        }

        public void Update(ProductModel product)
        {
            var updatedProduct = GetByProductCode(product.ProductCode);
            updatedProduct.Price = product.Price;
            //updatedProduct.ProductCode = product.ProductCode;
            updatedProduct.Stock = product.Stock;
            _db.Update(updatedProduct);
            _db.SaveChanges();
        }
    }
}

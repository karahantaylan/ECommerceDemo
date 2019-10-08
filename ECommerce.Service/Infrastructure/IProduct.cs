using ECommerce.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Service.Infrastructure
{
    public interface IProduct
    {
        ProductModel Add(ProductModel product);
        IEnumerable<ProductModel> GetAll();
        ProductModel GetByProductCode(int productCode);
        void Update(ProductModel product);
    }
}

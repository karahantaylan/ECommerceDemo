
using ECommerce.Service.Infrastructure;
using ECommerce.Service.DataService;
using ECommerce.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace ECommerce.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productRepository;

        public ProductController(IProduct productRepository)
        {
            _productRepository = productRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return _productRepository.GetAll();
        }

        // GET product/2
        [HttpGet("{productCode}", Name = "GetProduct")]
        public ActionResult<ProductModel> Get(int productCode)
        {
            var product = _productRepository.GetByProductCode(productCode);

            if (product == null)
            {
                return NotFound();
            }

            Debug.WriteLine("Product " + product.ProductCode + " info; price " + product.Price + ", stock " + product.Stock);
            return Ok(product);
        }

        // POST product
        [HttpPost]
        public ActionResult<ProductModel> Post([FromBody]ProductModel value)
        {
            if (value == null)
            {
                return NotFound();
            }
            var product = _productRepository.Add(value);

            Debug.WriteLine("Product created; code " + product.ProductCode +", price " + product.Price + ", stock " + product.Stock);
            return Ok(product);
        }
    }
}

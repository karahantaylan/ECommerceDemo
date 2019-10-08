using ECommerce.Model;
using ECommerce.WebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ECommerce.Test
{

    public class ProductControllerTest
    {
        ProductController _controller;
        ProductServiceFake _service;

        public ProductControllerTest()
        {
           _service = new ProductServiceFake();
            _controller = new ProductController(_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get() as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<ProductModel>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get(4);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var testId = 2;

            // Act
            var okResult = _controller.Get(testId);
            
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            var productCode = 2;

            // Act
            var okResult = _controller.Get(productCode);

            // Assert
            //Assert.IsType<ProductModel>(okResult.Result);
            Assert.Equal(productCode, (okResult.Value as ProductModel).ProductCode);
        }
    }


}

using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IEnumerable<Products> GetProducts()
        {
            return productService.GetProducts();
        }
        [HttpGet("{id}")]
        public Products GetProducts(Guid id)
        {
            return productService.GetProduct(id);
        }
        [HttpPost]
        public CommonMesssage SaveProduct(Products Products)
        {
            return productService.SaveProduct(Products);

        }
        [HttpPut]
        public CommonMesssage UpdateProduct(Products Products)
        {
            return productService.UpdateProduct(Products);
        }
        [HttpDelete]
        public CommonMesssage DeleteProduct(Guid id)
        {
            return productService.DeleteProduct(id);
        }
    }
}

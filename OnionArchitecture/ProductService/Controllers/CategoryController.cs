using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return categoryService.GetCategories();
        }
        [HttpGet("{id}")]
        public Category GetCategory(Guid id)
        {
            return categoryService.GetCategory(id);
        }
        [HttpPost]
        public CommonMesssage SaveCategory(Category category)
        {
            return categoryService.SaveCategory(category);
        }
        [HttpPut]
        public CommonMesssage UpdateCategory(Category category)
        {
            return categoryService.UpdateCategory(category);
        }
        [HttpDelete]
        public CommonMesssage DeleteCategory(Guid id)
        {
            return categoryService.DeleteCategory(id);
        }

    }
}

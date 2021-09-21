using DomainLayer.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        Category GetCategory(Guid id);
        CommonMesssage SaveCategory(Category category);
        CommonMesssage UpdateCategory(Category category);
        CommonMesssage DeleteCategory(Guid  id);
    }
}

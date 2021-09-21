using DomainLayer.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class MockCategoryService : ICategoryService 
    {
        private IRepository<Category> categoryRepository;
        public MockCategoryService(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public IEnumerable<Category> GetCategories()
        {
            return categoryRepository.GetAll();
        }
        public Category GetCategory(Guid id)
        {
            return categoryRepository.Where(i=>i.CategoryId == id).FirstOrDefault();
        }

        public CommonMesssage SaveCategory(Category category)
        {
            using (CommonMesssage commonMesssage = new CommonMesssage())
            {
                category.CategoryId = Guid.NewGuid();
                categoryRepository.Insert(category);
                int op = categoryRepository.SaveChanges();
                if (op > 0)
                {
                    commonMesssage.Result = 1;
                    commonMesssage.Message = "Saved Successfully";
                    commonMesssage.Object = category;
                }
                else
                {
                    commonMesssage.Result = -1;
                    commonMesssage.Message = "Saved Failed"; 
                }
                return commonMesssage;
            }
              
        }
        public CommonMesssage UpdateCategory(Category category)
        {
            using (CommonMesssage commonMesssage = new CommonMesssage())
            {
               if(categoryRepository.Any(i=>i.CategoryId == category.CategoryId))
                {
                    categoryRepository.Update(category);
                    int op = categoryRepository.SaveChanges();
                    if (op > 0)
                    {
                        commonMesssage.Result = 1;
                        commonMesssage.Message = "Update Successfully.";
                        commonMesssage.Object = category;
                    }
                    else
                    {
                        commonMesssage.Result = -2;
                        commonMesssage.Message = "Save Failed.";
                    }
                }
               else
                {
                    commonMesssage.Result = -1;
                    commonMesssage.Message = "Record Not Found.";
                }
                
                return commonMesssage;
            }

        }
        public CommonMesssage DeleteCategory(Guid guid)
        {
            using (CommonMesssage commonMesssage = new CommonMesssage())
            {
                if (categoryRepository.Any(i=>i.CategoryId == guid))
                {
                    categoryRepository.Remove(categoryRepository.Where(i=>i.CategoryId == guid).FirstOrDefault());
                    int op = categoryRepository.SaveChanges();
                    if (op > 0)
                    {
                        commonMesssage.Result = 1;
                        commonMesssage.Message = "Deleted Successfully.";
                        
                    }
                    else
                    {
                        commonMesssage.Result = -2;
                        commonMesssage.Message = "Delete Failed.";
                    }
                }
                else
                {
                    commonMesssage.Result = -1;
                    commonMesssage.Message = "Record Not Found.";
                }

                return commonMesssage;
            }

        }
    }
}

using DomainLayer.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class MockProductService : IProductService
    {
        public IRepository<Products> productRepository;

        public MockProductService(IRepository<Products> productRepository)
        {
            this.productRepository = productRepository;
        }

  
        public IEnumerable<Products> GetProducts()
        {
            return productRepository.GetAll();
        }
        public Products GetProduct(Guid id)
        {
            return productRepository.Where(i=>i.ProductId == id).FirstOrDefault();
        }

        public IEnumerable<Products> GetProductsByCategory(Guid CategoryId)
        {
            return productRepository.Where(i => i.CategoryId == CategoryId).ToList();
        }
        public CommonMesssage SaveProduct(Products product)
        {
            using (CommonMesssage commonMesssage = new CommonMesssage())
            {
                product.ProductId = Guid.NewGuid();
                productRepository.Insert(product);
                int op = productRepository.SaveChanges();
                if (op > 0)
                {
                    commonMesssage.Result = 1;
                    commonMesssage.Message = "Saved Successfully";
                    commonMesssage.Object = product;
                }
                else
                {
                    commonMesssage.Result = -1;
                    commonMesssage.Message = "Saved Failed";
                }
                return commonMesssage;
            }
        }
        public CommonMesssage UpdateProduct(Products product)
        {
            using (CommonMesssage commonMesssage = new CommonMesssage())
            {
                if (productRepository.Any(i => i.ProductId == product.ProductId))
                {
                    productRepository.Update(product);
                    int op = productRepository.SaveChanges();
                    if (op > 0)
                    {
                        commonMesssage.Result = 1;
                        commonMesssage.Message = "Update Successfully.";
                        commonMesssage.Object = product;
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
        public CommonMesssage DeleteProduct(Guid id)
        {
            using (CommonMesssage commonMesssage = new CommonMesssage())
            {
                if (productRepository.Any(i=>i.ProductId == id))
                {
                    productRepository.Remove(productRepository.Where(i=>i.ProductId == id).FirstOrDefault());
                    int op = productRepository.SaveChanges();
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

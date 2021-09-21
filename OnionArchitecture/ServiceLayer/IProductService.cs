using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IProductService
    {
        IEnumerable<Products> GetProducts();
        Products GetProduct(Guid id);
        CommonMesssage UpdateProduct(Products products);
        CommonMesssage SaveProduct(Products products);
        CommonMesssage DeleteProduct(Guid id);
    }
}

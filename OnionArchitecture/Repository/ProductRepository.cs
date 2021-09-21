using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;
using System.Linq.Expressions;

namespace Repository
{
    public class ProductRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ProductContext productContext;
        private  DbSet<TEntity> entities;

        public ProductRepository(ProductContext productContext)
        {
            this.productContext = productContext;
            entities = productContext.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetAll()
        {
            var list = entities.ToList();
            return list;
        }

        public void Insert(TEntity entity)
        {
            entities.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            entities.Remove(entity);
        }

        public int SaveChanges()
        {
            return productContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            entities.Update(entity);
        }

        //public TEntity GetById(Guid id)
        //{
        //   return entities.Where(i => i.ProductId == id).FirstOrDefault();
        //}

        //public bool IsExist(Guid id)
        //{
        //    return entities.Any(i=>i.ProductId == id);
        //}

        public TEntity GetByFilter(Expression<Func<TEntity, bool>> expression)
        {
            entities.Where(expression).FirstOrDefault();
            throw new NotImplementedException();
        }
    }
}

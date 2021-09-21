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
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ProductContext productContext;
        private DbSet<TEntity> entities;

        public Repository(ProductContext productContext)
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

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return entities.Where(expression).AsQueryable();
        }

        public bool Any(Expression<Func<TEntity, bool>> expression)
        {
            return entities.Any(expression);
        }

        public IQueryable<TEntity> Query()
        {
            return entities.AsQueryable();
        }
    }
}

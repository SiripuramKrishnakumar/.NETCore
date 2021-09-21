using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DomainLayer.Models;
using System.Linq.Expressions;

namespace Repository
{
    public interface IRepository<TEntity> 
    {
        IEnumerable<TEntity> GetAll();
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        bool Any(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> Where(Expression<Func<TEntity,bool>> expression);
        IQueryable<TEntity> Query();

        int SaveChanges();
    }
}

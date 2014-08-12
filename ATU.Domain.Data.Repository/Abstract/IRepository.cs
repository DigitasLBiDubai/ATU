using System;
using System.Linq;
using System.Linq.Expressions;

namespace ATU.Domain.Data.Repository.Abstract
{
    public interface IRepository : IDisposable
    {
        IQueryable<TEntity> GetAll<TEntity>();
        IQueryable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate);
        TEntity Single<TEntity>(Expression<Func<TEntity, bool>> predicate);
        TEntity First<TEntity>(Expression<Func<TEntity, bool>> predicate);
        void Add<TEntity>(TEntity entity);
        void Delete<TEntity>(TEntity entity);
        void Attach<TEntity>(TEntity entity);
        void SaveChanges();
        void DeployMembershipDatabase();
    }
}
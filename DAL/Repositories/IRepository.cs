using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity FindEntity(int id);
        IEnumerable<TEntity> GetALl();
        IEnumerable<TEntity> GetMany(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> GetAllWithInclude(params Expression<Func<TEntity, object>>[] include);
        IEnumerable<TEntity> GetAllWithMultipleIncludes<TProp, Tprop2, Tprop3>(Expression<Func<TEntity, TProp>>[] include1,
                                                                                    Expression<Func<TEntity, Tprop2>>[] include2,
                                                                                    params Expression<Func<TEntity, Tprop3>>[] include3);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        TEntity Update(TEntity entity);
        IQueryable<TEntity> Query();
        void Save();
    }
}
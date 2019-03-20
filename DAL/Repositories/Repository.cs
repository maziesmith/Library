using DAL.ContextFolder;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
   public class Repository<TEntity> : IRepository<TEntity> where TEntity:class
    {
        private Context _context;
        private DbSet<TEntity> Entities;
        string errorMessage = string.Empty;

        public Repository(Context context)
        {
            _context = context;
            Entities = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetALl()
        {
            return Entities.AsEnumerable();
        }
        public IEnumerable<TEntity> GetAllWithInclude(params Expression<Func<TEntity,object>>[] include)
        {
            var query = Entities.AsQueryable();
            //for (int i = 0; i < include.Length; i++)
            //{
            //    query = query.Include(include[i]);
            //}
           return include.Aggregate(query, (curent, inc) => curent.Include(inc));
            
        }
        public IEnumerable<TEntity> GetAllWithMultipleIncludes<TProp,Tprop2,Tprop3>( Expression<Func<TEntity,TProp>>[]include1 , 
                                                                                    Expression<Func<TEntity,Tprop2>>[] include2,
                                                                                    params Expression<Func<TEntity,Tprop3>>[] include3)
        {
            var query = Entities.AsQueryable();
            var query1=include1.Aggregate(query, (current, inc) => current.Include(inc)).AsQueryable();
            query1=include2.Aggregate(query1, (current, inc) => current.Include(inc)).AsQueryable();
            query1 = include3.Aggregate(query1, (current, inc) => current.Include(inc));
            return query1;
        }
        public TEntity FindEntity(int id)
        {
            return Entities.Find(id);
        }

        public IEnumerable<TEntity> GetMany(Func<TEntity,bool> predicate)
        {
            return Entities.Where(predicate).AsEnumerable();
        }

        
        public void Insert(TEntity entity)
        {
          try
            {
                if(entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                Entities.Add(entity);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(errorMessage, dbEx);
            }

            //  Entities.Add(entity);
          //  _context.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
          try
            {
                if(entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                Entities.Remove(entity);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach(var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach(var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                throw new Exception(errorMessage, dbEx);
            }
            //  Entities.Remove(entity);
          //  _context.SaveChanges();
        }
        public TEntity Update(TEntity entity)
        {
            try
            {
                if(entity==null)
                {
                    throw new ArgumentNullException("entity");
                }
                Entities.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
                return entity;
            }
            catch(DbEntityValidationException dbEx)
            {
                foreach(var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach(var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                throw new Exception(errorMessage, dbEx);
            }


            //_context.Entry(entity).State = EntityState.Modified; 
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IQueryable<TEntity> Query()
        {
            return Entities.AsNoTracking().AsQueryable();
        }
    }
}

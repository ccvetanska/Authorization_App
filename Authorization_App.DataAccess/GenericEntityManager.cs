using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Authorization_App.Model;

namespace Authorization_App.DataAccess
{
    public class GenericEntityManager<K, T> where T : class, IEntity
    {
        protected DbContext _context;
        protected DbSet<T> _entities;
        

        public GenericEntityManager(DbContext ctx)
        {
            _context = ctx;
            _entities = _context.Set<T>();
        }

        public T Add(T entity)
        {
            T result = _entities.Add(entity);
            _context.SaveChanges();
            return result;
        }

        public bool Delete(K id)
        {
            T foundEntity = _entities.Find(new K[1] { id });

            if (foundEntity != null)
            {
                _entities.Remove(foundEntity);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public T Update(T entity)
        {
            T result = _entities.Attach(entity);
            _context.SaveChanges();

            return result;
        }

        public T Find(K id)
        {
            //T foundEntity = _entities.Find(new K[1] { id });

            T foundEntity = _entities.Find(id);
            return foundEntity;
        }
       
        public IQueryable<T> Query()
        {
            return _entities.AsQueryable();
        }

    }
}
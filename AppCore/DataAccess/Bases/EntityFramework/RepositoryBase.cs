using AppCore.Records.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AppCore.DataAccess.Bases.EntityFramework
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : RecordBase, new()
    {
        private readonly DbContext _db;

        public RepositoryBase(DbContext db)
        {
            _db = db;
        }

        public void Add(TEntity entity, bool save = true)
        {
            try
            {
                entity.Guid = Guid.NewGuid().ToString();

                _db.Set<TEntity>().Add(entity);
                if (save)
                    Save();
            }
            catch (Exception exc)
            {

                throw exc;
            }

        }

        public int Save()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch (Exception exc)
            {

                throw exc;
            }

        }

        public void Delete(TEntity entity, bool save = true)
        {
            try
            {
                _db.Set<TEntity>().Remove(entity);
                if (save)
                    Save();
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

      public virtual void Delete(int id, bool save = true)
        {
            try
            {
                TEntity entity = EntityQuery(e => e.Id == id).SingleOrDefault();
                Delete(entity, save);
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
        public IQueryable<TEntity> Query()
        {
            return _db.Set<TEntity>().AsQueryable();

        }

        public virtual IQueryable<TEntity> EntityQuery(params string[] entitiesToInclude)
        {
            var query = Query();

            foreach (var entityToInclude in entitiesToInclude)
            {
                query = query.Include(entityToInclude);
            }

            return query;
        }

        public virtual IQueryable<TEntity> EntityQuery(Expression<Func<TEntity, bool>> predicate, params string[] entitiesToInclude)
        {
            var query = EntityQuery(entitiesToInclude);
            return query.Where(predicate);
        }

        public void Update(TEntity entity, bool save = true)
        {
            try
            {
                _db.Set<TEntity>().Update(entity);
                if (save)
                    Save();
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        private bool _disposed = false;

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _db?.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.EntityModels.Interfaces;

namespace VMSCore.Infrastructure.Base.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected EntityDataContext _context;

        public BaseRepository(EntityDataContext dbContext)
        {
            _context = dbContext;
        }

        public BaseRepository()
        {
            _context = new EntityDataContext();
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void DeleteRange(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }
        public void AddRange(List<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public T GetByCode(string code)
        {
            if (typeof(ICodedEntity).IsAssignableFrom(typeof(T)))
            {
                return _context.Set<T>().SingleOrDefault(e => ((ICodedEntity)e).Code == code);
            }

            throw new InvalidOperationException("This method can't be called on an entity without a Code property");
        }

        public T GetByIdStr(string id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        // Example: var result = _repository.GetAll(x => x.Id, 0, 10);
        public List<T> GetAllByCondition(Func<T, bool> expression, Func<T, object> orderBy = null, int skip = 0, int take = int.MaxValue)
        {
            //IQueryable<T> query = (IQueryable<T>)_context.Set<T>().Where(expression);
            var query = _context.Set<T>().Where(expression);
            if (orderBy != null)
            {
                query = (IQueryable<T>)query.OrderBy(orderBy);
            }
            return query.Skip(skip).Take(take).ToList();
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        // Example: _repository.UpdateByCondition(x => x.Id == id, x => x.Name = "New Name");

        /*
         Example: 
            _repository.UpdateByCondition(x => x.Id == id, x => {
                x.Name = "New Name";
                x.Description = "New Description";
            });
         */

        public void UpdateByCondition(Func<T, bool> expression, Action<T> action)
        {
            var entities = _context.Set<T>().Where(expression);
            foreach (var entity in entities)
            {
                action(entity);
            }
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        // Example: _repository.DeleteByCondition(x => x.Id == id);
        public void DeleteByCondition(Func<T, bool> expression)
        {
            var entities = _context.Set<T>().Where(expression);
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }

        public void DeleteById(Guid id)
        {
            var entity = GetById(id);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public int DeleteByIdStr(string id)
        {
            var entity = GetByIdStr(id);
            _context.Set<T>().Remove(entity);
            var rowsAffected = _context.SaveChanges();
            return rowsAffected;
        }

        public void DeleteRangeById(List<Guid> ids)
        {
            var entities = new List<T>();
            foreach (var id in ids)
            {
                var entity = GetById(id);
                entities.Add(entity);
            }
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }

        public void DeleteRangeByIdStr(List<string> ids)
        {
            var entities = new List<T>();
            foreach (var id in ids)
            {
                var entity = GetByIdStr(id);
                entities.Add(entity);
            }
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }
        public T GetOneByCondition(Func<T, bool> expression)
        {
            return _context.Set<T>().Where(expression).FirstOrDefault();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
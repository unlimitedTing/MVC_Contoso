using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Contoso.Data
{
    public class Repository<T>:IRepository<T> where T:class
    {
        protected ContosoDbContext _dbContext;// used for private usage, protected enable only derived class to access it

        protected Repository(ContosoDbContext context) // constructor, but what is the context?
        {
            _dbContext = context;
        }

        public virtual void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;// change the state of entity to be modified? 
        }

        public virtual void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            var objects = _dbContext.Set<T>().Where(where).AsEnumerable();
            foreach (var obj in objects)
                _dbContext.Set<T>().Remove(obj);
        }

        public virtual T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public int GetCount(Expression<Func<T, bool>> filter = null)
        {
            return filter != null ? _dbContext.Set<T>().Where(filter).Count() : _dbContext.Set<T>().Count();
        }
        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return _dbContext.Set<T>().Where(where).FirstOrDefault();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking().ToList();// AsNoTracking would return a new entity which not be cached, to be faster
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbContext.Set<T>().Where(where).ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
